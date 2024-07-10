using System.Linq.Expressions;
using BoletoBus.Viaje.Domain.Interfaces;
using BoletoBus.Viaje.Persistance.Context;
using BoletoBus.Viaje.Persistance.Exceptions;

namespace BoletoBus.Viaje.Persistance.Repositories
{
    public class ViajeRepository : IViajeRepository
    {
        private readonly BoletoBusContext context;

        public ViajeRepository(BoletoBusContext context)
        {
            this.context = context;
        }

        private Domain.Entities.Viaje GetViajeById(int idViaje)
        {
            var viaje = this.context.Viaje.Find(idViaje);
            if (viaje == null)
            {
                throw new ViajeException("Viaje no encontrado");
            }
            return viaje;
        }

        public void Agregar(Domain.Entities.Viaje entity)
        {
            this.context.Viaje.Add(entity);
            this.context.SaveChanges();
        }

        public void Editar(Domain.Entities.Viaje entity)
        {
            var viaje = GetViajeById(entity.Id);

            viaje.IdBus = entity.IdBus;
            viaje.IdRuta = entity.IdRuta;
            viaje.FechaSalida = entity.FechaSalida;
            viaje.HoraSalida = entity.HoraSalida;
            viaje.FechaLlegada = entity.FechaLlegada;
            viaje.HoraLlegada = entity.HoraLlegada;
            viaje.Precio = entity.Precio;
            viaje.TotalAsientos = entity.TotalAsientos;
            viaje.AsientosReservados = entity.AsientosReservados;

            this.context.Viaje.Update(viaje);
            this.context.SaveChanges();
        }

        public void Eliminar(Domain.Entities.Viaje entity)
        {
            var viaje = GetViajeById(entity.Id);

            this.context.Viaje.Remove(viaje);
            this.context.SaveChanges();
        }

        public bool Exists(Expression<Func<Domain.Entities.Viaje, bool>> filter)
        {
            return this.context.Viaje.Any(filter);
        }

        public List<Domain.Entities.Viaje> GetAll()
        {
            return this.context.Viaje.OrderByDescending(v => v.FechaCreacion).ToList();
        }

        public Domain.Entities.Viaje GetEntityBy(int id)
        {
            return GetViajeById(id);
        }

        public List<Domain.Entities.Viaje> GetViajesByID(int idViaje)
        {
            return this.context.Viaje.Where(v => v.Id == idViaje).ToList();
        }
    }
}
