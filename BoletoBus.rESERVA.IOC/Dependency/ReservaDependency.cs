using BoletoBus.Reserva.Application.Interfaces;
using BoletoBus.Reserva.Application.Services;
using BoletoBus.Reserva.Domain.Interfaces;
using BoletoBus.Reserva.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BoletoBus.rESERVA.IOC.Dependency
{
    public static class ReservaDependency
    {
        public static void AddReservaDependency(this IServiceCollection services)
        {
            #region "Repositorios"
            services.AddScoped<IReservaRepository, ReservaRepository>();
            #endregion

            #region "Servisec"
            services.AddTransient<IReservaServices, ReservaServices>();
            #endregion
        }
    }
}