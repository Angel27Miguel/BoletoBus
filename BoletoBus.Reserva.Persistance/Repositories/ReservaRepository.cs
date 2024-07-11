using BoletoBus.Empleado.Persistance.Context;
using BoletoBus.Reserva.Domain.Entities;
using BoletoBus.Reserva.Domain.Interfaces;
using BoletoBus.Reserva.Persistance.Exceptions;
using System.Linq.Expressions;

namespace BoletoBus.Reserva.Persistance.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly BoletoBusContext context;

        public ReservaRepository(BoletoBusContext context)
        {
            this.context = context;
        }

        public void Agregar(Reservas entity)
        {
            Reservas reserva = new()
            {
                IdViaje = entity.IdViaje,
                IdPasajero = entity.IdPasajero,
                AsientosReservados = entity.AsientosReservados,
                MontoTotal = entity.MontoTotal,
                FechaCreacion = entity.FechaCreacion
            };

            this.context.Add(reserva);
            this.context.SaveChanges();
        }

        public void Editar(Reservas entity)
        {
            var reserva = GetReservaId(entity.Id);

            reserva.IdViaje = entity.IdViaje;
            reserva.IdPasajero = entity.IdPasajero;
            reserva.AsientosReservados = entity.AsientosReservados;
            reserva.MontoTotal = entity.MontoTotal;

            this.context.Update(reserva);
            this.context.SaveChanges();
        }

        public void Eliminar(Reservas entity)
        {
            var reserva = GetReservaId(entity.Id);

            this.context.Reserva.Remove(reserva);
            this.context.SaveChanges();
        }

        public bool Exists(Expression<Func<Reservas, bool>> filter)
        {
            return this.context.Reserva.Any(filter);
        }

        public List<Reservas> GetAll()
        {
            return this.context.Reserva.Select(reserva => new Reservas()
            {
                Id = reserva.Id,
                IdViaje = reserva.IdViaje,
                IdPasajero = reserva.IdPasajero,
                AsientosReservados = reserva.AsientosReservados,
                MontoTotal = reserva.MontoTotal,
                FechaCreacion = reserva.FechaCreacion
            }).ToList();
        }

        public Reservas GetEntityBy(int id)
        {
            var reserva = GetReservaId(id);
            return new Reservas()
            {
                Id = reserva.Id,
                IdViaje = reserva.IdViaje,
                IdPasajero = reserva.IdPasajero,
                AsientosReservados = reserva.AsientosReservados,
                MontoTotal = reserva.MontoTotal,
                FechaCreacion = reserva.FechaCreacion
            };
        }

        public List<Reservas> GetReservasByID(int IdReserva)
        {
            return this.context.Reserva.Where(r => r.Id == IdReserva).Select(reserva => new Reservas()
            {
                Id = reserva.Id,
                IdViaje = reserva.IdViaje,
                IdPasajero = reserva.IdPasajero,
                AsientosReservados = reserva.AsientosReservados,
                MontoTotal = reserva.MontoTotal,
                FechaCreacion = reserva.FechaCreacion
            }).ToList();
        }

        private Reservas GetReservaId(int idReserva)
        {
            var reserva = this.context.Reserva.Find(idReserva);
            if (reserva == null)
            {
                throw new ReservaException("Reserva no encontrada");
            }
            return reserva;
        }
    }
}
