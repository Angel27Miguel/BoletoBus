using BoletoBus.Empleado.Application.Interfaces;
using BoletoBus.Empleado.Application.Services;
using BoletoBus.Empleado.Domain.Interfaces;
using BoletoBus.Empleado.Persistance.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BoletoBus.Empleado.IOC.Dependencies
{
    public static class EmpleadoDependency
    {
        public static void GuardarEmpleadoDependencies(this ServiceCollection services)
        {
            #region "Repositorios"
            services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
            #endregion

            #region "Servisec"
            services.AddTransient<IEmpleadoServices, EmpleadoServices>();
            #endregion
        }
    }
}
