using BoletoBus.Viaje.Domain.Interfaces;
using System.Linq.Expressions;

namespace BoletoBus.Viaje.Persistance.Repositories
{
    public class ViajeRepository : IViajeRepository
    {
        public void Agregar(Domain.Entities.Viaje entity)
        {
            throw new NotImplementedException();
        }

        public void Editar(Domain.Entities.Viaje entity)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Domain.Entities.Viaje entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<Domain.Entities.Viaje, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Viaje> GetAll()
        {
            throw new NotImplementedException();
        }

        public Domain.Entities.Viaje GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }

        public List<Domain.Entities.Viaje> GetViajesByID(int idViaje)
        {
            throw new NotImplementedException();
        }
    }
}
