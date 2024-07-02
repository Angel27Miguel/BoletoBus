



using BoletoBus.Entidades.Domain.Interfaces.IViaje;
using System.Linq.Expressions;

namespace BoletoBus.Viaje.Persistance.Repositories
{
    public class ViajeRepository : IViajeRepository
    {
        public void Agregar(Entidades.Domain.Entities.Viaje.Viaje entity)
        {
            throw new NotImplementedException();
        }

        public void Editar(Entidades.Domain.Entities.Viaje.Viaje entity)
        {
            throw new NotImplementedException();
        }

        public void Eliminar(Entidades.Domain.Entities.Viaje.Viaje entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<Entidades.Domain.Entities.Viaje.Viaje, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Entidades.Domain.Entities.Viaje.Viaje> GetAll()
        {
            throw new NotImplementedException();
        }

        public Entidades.Domain.Entities.Viaje.Viaje GetEntityBy(int id)
        {
            throw new NotImplementedException();
        }

        public List<Entidades.Domain.Entities.Viaje.Viaje> GetViajesByID(int idViaje)
        {
            throw new NotImplementedException();
        }
    }
}
