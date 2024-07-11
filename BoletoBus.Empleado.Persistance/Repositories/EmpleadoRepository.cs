using System.Linq.Expressions;
using BoletoBus.Empleado.Domain.Entities;
using BoletoBus.Empleado.Domain.Interfaces;
using BoletoBus.Empleado.Persistance.Context;
using BoletoBus.Empleado.Persistance.Exceptions;
using Microsoft.Extensions.Logging;

namespace BoletoBus.Empleado.Persistance.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly BoletoBusContext context;
        private readonly ILogger<EmpleadoRepository> logger;
        private readonly IEmpleadoRepository empleadoRepository;

        public EmpleadoRepository(BoletoBusContext context, ILogger<EmpleadoRepository> logger, IEmpleadoRepository empleadoRepository)
        {
            this.context = context;
            this.logger = logger;
            this.empleadoRepository = empleadoRepository;
        }

        private Empleados GetEmpleadoById(int idEmpleado)
        {
            var empleado = this.context.Empleado.Find(idEmpleado);
            if (empleado == null)
            {
                this.logger.LogWarning("Empleado no encontrado, ID: {IdEmpleado}", idEmpleado);
                throw new EmpleadosException("Empleado no encontrado");
            }
            return empleado;
        }

        public void Agregar(Empleados entity)
        {
            this.context.Empleado.Add(entity);
            this.context.SaveChanges();
            this.logger.LogInformation("Empleado agregado, ID: {Id}", entity.Id);
        }

        public void Editar(Empleados entity)
        {
            var empleado = GetEmpleadoById(entity.Id);
            empleado.Nombre = entity.Nombre;
            empleado.Cargo = entity.Cargo;

            this.context.Empleado.Update(empleado);
            this.context.SaveChanges();
            this.logger.LogInformation("Empleado editado, ID: {Id}", entity.Id);
        }

        public void Eliminar(Empleados entity)
        {
            var empleado = GetEmpleadoById(entity.Id);
            this.context.Empleado.Remove(empleado);
            this.context.SaveChanges();
            this.logger.LogInformation("Empleado eliminado, ID: {Id}", entity.Id);
        }

        public bool Exists(Expression<Func<Empleados, bool>> filter)
        {
            return this.context.Empleado.Any(filter);
        }

        public List<Empleados> GetAll()
        {
            return this.context.Empleado.OrderByDescending(e => e.Id).ToList();
        }

        public Empleados GetEntityBy(int id)
        {
            return GetEmpleadoById(id);
        }

        public List<Empleados> GetEmpleadosByID(int idEmpleado)
        {
            return this.context.Empleado.Where(e => e.Id == idEmpleado).ToList();
        }
    }
}
