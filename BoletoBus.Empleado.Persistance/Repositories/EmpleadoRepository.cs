using BoletoBus.Empleado.Domain.Entities;
using BoletoBus.Empleado.Domain.Interfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using BoletoBus.Empleado.Persistance.Context;
using BoletoBus.Empleado.Persistance.Exceptions;
using BoletoBus.Empleado.Application.Dtos;


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
            this.context.Empleado.Update(entity);
            this.context.SaveChanges();
        }

        public void Eliminar(Empleados entity)
        {
            this.context.Empleado.Remove(entity);
            this.context.SaveChanges();
        }

        public bool Exists(Expression<Func<Empleados, bool>> filter)
        {
            return this.context.Empleado.Any(filter);
        }

        public List<Empleados> GetAll()
        {
            return this.context.Empleado.ToList();
        }

        public List<Empleados> GetEmpleadosByID(int idViaje)
        {
            return this.context.Empleado.Where(e => e.Id == idViaje).ToList();
        }

        public Empleados GetEntityBy(int id)
        {
            return GetEmpleadoById(id);
        }

        public void EditarEmpleados(EmpleadosEditarModel empleadosEditar)
        {
            var empleado = GetEmpleadoById(empleadosEditar.IdEmpleado);
            empleado.Nombre = empleadosEditar.Nombre;
            empleado.Cargo = empleadosEditar.Cargo;
            this.context.Empleado.Update(empleado);
            this.context.SaveChanges();
        }

        public void EliminarEmpleados(EmpleadosEliminarModel empleadosEliminar)
        {
            var empleado = GetEmpleadoById(empleadosEliminar.IdEmpleado);
            this.context.Empleado.Remove(empleado);
            this.context.SaveChanges();
        }

        public EmpleadosModel GetEmpleado(int idEmpleado)
        {
            var empleado = GetEmpleadoById(idEmpleado);
            return new EmpleadosModel
            {
                IdEmpleado = empleado.Id,
                Nombre = empleado.Nombre,
                Cargo = empleado.Cargo
            };
        }

        public List<EmpleadosModel> GetEmpleados()
        {
            return this.context.Empleado.Select(e => new EmpleadosModel
            {
                IdEmpleado = e.Id,
                Nombre = e.Nombre,
                Cargo = e.Cargo
            }).ToList();
        }

        public void GuardarEmpleado(EmpleadosGuardarModel empleadosGuardar)
        {
            Empleados empleado = new Empleados
            {
                Nombre = empleadosGuardar.Nombre,
                Cargo = empleadosGuardar.Cargo
            };
            this.context.Empleado.Add(empleado);
            this.context.SaveChanges();
        }
    }
}
