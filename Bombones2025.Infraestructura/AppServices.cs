using Bombones2025.DatosSql;
using Bombones2025.DatosSql.Interfaces;
using Bombones2025.DatosSql.Repositorios;
using Bombones2025.Servicios.Interfaces;
using Bombones2025.Servicios.Mappings;
using Bombones2025.Servicios.Servicios;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;

namespace Bombones2025.Infraestructura
{
    public static class AppServices
    {
        private static IServiceProvider? _serviceProvider;

        public static void Inicializar()
        {
            var services = new ServiceCollection();

            services.AddDbContext<BombonesDbContext>(options =>
            {
                options.UseSqlServer(ConfigurationManager.ConnectionStrings["MiConexion"]
                    .ConnectionString);
            });

            services.AddScoped<IPaisRepositorio, PaisRepositorio>();
            services.AddScoped<IRellenoRepositorio, RellenoRepositorio>();
            services.AddScoped<IChocolateRepositorio, ChocolateRepositorio>();
            services.AddScoped<IFrutoSecoRepositorio, FrutoSecoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<IProvinciaEstadoRepositorio, ProvinciaEstadoRepositorio>();

            services.AddScoped<IPaisServicio, PaisServicio>();
            services.AddScoped<IRellenoServicio, RellenoServicio>();
            services.AddScoped<IChocolateServicio, ChocolateServicio>();
            services.AddScoped<IFrutoSecoServicio, FrutoSecoServicio>();
            services.AddScoped<IUsuarioServicio, UsuarioServicio>();
            services.AddScoped<IProvinciaEstadoServicio, ProvinciaEstadoServicio>();

            services.AddAutoMapper(typeof(MappingProfile).Assembly);
            _serviceProvider = services.BuildServiceProvider();

        }
        public static IServiceProvider? ServiceProvider =>
            _serviceProvider ?? throw new NotImplementedException("Dependencias no establecidas");
    }
}
