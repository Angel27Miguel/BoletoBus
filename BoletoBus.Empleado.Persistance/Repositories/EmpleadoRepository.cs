using BoletoBus.Empleado.Domain.Entities;
using BoletoBus.Empleado.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus.Empleado.Persistance.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        public void Agregar(Empleados entity)
        {
            throw new NotImplementedException();
        }

        public void Editar(Empleados entity)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Empleados entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<Empleados, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Empleados> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Empleados> GetEmpleadosByID(int idViaje)
        {
            throw new NotImplementedException();
        }

        public Empleados GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }
    }
}
