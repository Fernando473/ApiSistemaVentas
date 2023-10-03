using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.DAL.Repositorios.Contratos;
using SistemaVentas.DAL.DBContext;


namespace SistemaVenta.DAL.Repositorios
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly DbventasContext _dbventasContext;

        public GenericRepository(DbventasContext dbventasContext)
        {
            _dbventasContext= dbventasContext;
        }

        public async Task<IQueryable<T>> Consultar(Expression<Func<T, bool>> filtro)
        {
            try
            {
                IQueryable<T> queryModelo = filtro == null ? _dbventasContext.Set<T>() : _dbventasContext.Set<T>().Where(filtro);
                return queryModelo;
            }catch{
                throw;
            }
        }

        public async Task<T> Crear(T entity)
        {
            try
            {
                _dbventasContext.Set<T>().Add(entity);
                await _dbventasContext.SaveChangesAsync();
                return entity;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(T entity)
        {
            try
            {
                _dbventasContext.Set<T>().Update(entity);
                await _dbventasContext.SaveChangesAsync();
                return true;

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(T entity)
        {
            try
            {
                _dbventasContext.Set<T>().Remove(entity);
                await _dbventasContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        
        public async Task<T> Obtener(Expression<Func<T, bool>> filtro)
        {
            try
            {
                T entity = await _dbventasContext.Set<T>().FirstOrDefaultAsync(filtro);
                return entity;
            }
            catch
            {
                throw;
            }
        }
    }
}
