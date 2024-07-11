
using BoletoBus.Viaje.Application.Interfaces;
using BoletoBus.Viaje.Application.Services;
using BoletoBus.Viaje.Domain.Interfaces;
using BoletoBus.Viaje.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BoletoBus.Viaje.IOC.Dependency
{
    public static class ViajeDependency
    {
        public static void AddViajeDependency(this IServiceCollection services)
        {
            #region "Repositorios"
            services.AddScoped<IViajeRepository, ViajeRepository>();
            #endregion

            #region "Servisec"
            services.AddTransient<IviajeServices, ViajeServices>();
            #endregion
        }
    }
}
