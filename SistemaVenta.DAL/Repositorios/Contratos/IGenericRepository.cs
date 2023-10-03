using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
namespace SistemaVenta.DAL.Repositorios.Contratos;

public interface IGenericRepository<T> where T : class
{
    Task<T> Obtener(Expression<Func<T,bool>> filtro);
    
    Task<T> Crear(T entity);
    
    Task<bool> Editar(T entity);

    Task<bool> Eliminar(T entity);

    Task<IQueryable<T>> Consultar(Expression<Func<T, bool>> filtro);

}
