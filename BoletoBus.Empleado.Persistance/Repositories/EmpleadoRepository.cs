
using System.Linq.Expressions;
using BoletoBus.Empleado.Domain.Entities;
using BoletoBus.Empleado.Domain.Interfaces;
using BoletoBus.Empleado.Persistance.Context;
using BoletoBus.Empleado.Persistance.Exceptions;

namespace BoletoBus.Empleado.Persistance.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly BoletoBusContext context;

        public EmpleadoRepository(BoletoBusContext context)
        {
            this.context = context;
        }

        private Empleados GetEmpleadoById(int idEmpleado)
        {
            var empleado = this.context.Empleado.Find(idEmpleado);
            if (empleado == null)
            {
                throw new EmpleadosException("Empleado no encontrado");
            }
            return empleado;
        }

        public void Agregar(Empleados entity)
        {
            this.context.Empleado.Add(entity);
            this.context.SaveChanges();
        }

        public void Editar(Empleados entity)
        {
            var empleado = GetEmpleadoById(entity.Id);
            empleado.Nombre = entity.Nombre;
            empleado.Cargo = entity.Cargo;

            this.context.Empleado.Update(empleado);
            this.context.SaveChanges();
        }

        public void Eliminar(Empleados entity)
        {
            var empleado = GetEmpleadoById(entity.Id);
            this.context.Empleado.Remove(empleado);
            this.context.SaveChanges();
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
