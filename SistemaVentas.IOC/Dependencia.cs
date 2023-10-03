using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaVentas.DAL.DBContext;
using Pomelo.EntityFrameworkCore.MySql;
using SistemaVenta.DAL.Repositorios.Contratos;
using SistemaVenta.DAL.Repositorios;

namespace SistemaVentas.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbventasContext>(options =>
            {
                options.UseMySql(configuration.GetConnectionString("cadenaSQL"),ServerVersion.AutoDetect(configuration.GetConnectionString("cadenaSQL")));
            });
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IVentaRepository,VentasRepository>();
        }

    }
}
