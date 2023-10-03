using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaVenta.DAL.Repositorios.Contratos;
using SistemaVentas.DAL.DBContext;
using SistemaVentas.MODEL;

namespace SistemaVenta.DAL.Repositorios
{
    public class VentasRepository : GenericRepository<Venta>, IVentaRepository
    {

        private readonly SistemaVentas.DAL.DBContext.DbventasContext _dbventasContext;
        public VentasRepository(SistemaVentas.DAL.DBContext.DbventasContext dbventasContext) : base(dbventasContext)
        {
            _dbventasContext = dbventasContext;
        }

        public async Task<Venta> Registrar(Venta venta)
        {
            Venta ventaGenerada = new Venta();

            using( var transaction  = _dbventasContext.Database.BeginTransaction() ) {
                try
                {
                    foreach(DetalleVenta dv  in venta.Detalleventa)
                    {
                        Producto productoEncontrado = _dbventasContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();
                        productoEncontrado.Stock = productoEncontrado.Stock - dv.Cantidad;
                        _dbventasContext.Productos.Update(productoEncontrado);
                    }
                    await _dbventasContext.SaveChangesAsync();
                    Numerodocumento correlativo = _dbventasContext.Numerodocumentos.First();

                    correlativo.UltimoNumero = correlativo.UltimoNumero + 1;
                    correlativo.FechaRegistro = DateTime.Now;
                    await _dbventasContext.SaveChangesAsync();

                    int cantidadDigitos = 4;
                    string ceros = string.Concat(Enumerable.Repeat("0", cantidadDigitos));
                    string numeroVenta = ceros + correlativo.UltimoNumero.ToString();
                    numeroVenta = numeroVenta.Substring(numeroVenta.Length - cantidadDigitos, cantidadDigitos);

                    venta.NumeroDocumento = numeroVenta;

                    _dbventasContext.Venta.Add(venta);

                    await _dbventasContext.SaveChangesAsync();

                    ventaGenerada = venta;

                    transaction.Commit();

                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }

            return ventaGenerada;
            }


        }
    }
}
