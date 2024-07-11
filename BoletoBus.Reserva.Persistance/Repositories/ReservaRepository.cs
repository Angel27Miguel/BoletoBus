using BoletoBus.Empleado.Persistance.Context;
using BoletoBus.Reserva.Domain.Entities;
using BoletoBus.Reserva.Domain.Interfaces;
using BoletoBus.Reserva.Persistance.Exceptions;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace BoletoBus.Reserva.Persistance.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        private readonly BoletoBusContext context;
        private readonly ILogger<ReservaRepository> logger;

        public ReservaRepository(BoletoBusContext context, ILogger<ReservaRepository> logger)
        {
            this.context = context;
            this.logger = logger;
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
            this.logger.LogInformation("Reserva agregada: {ReservaId}", reserva.Id);
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
            this.logger.LogInformation("Reserva editada: {ReservaId}", reserva.Id);
        }

        public void Eliminar(Reservas entity)
        {
            var reserva = GetReservaId(entity.Id);

            this.context.Reserva.Remove(reserva);
            this.context.SaveChanges();
            this.logger.LogInformation("Reserva eliminada: {ReservaId}", reserva.Id);
        }

        public bool Exists(Expression<Func<Reservas, bool>> filter)
        {
            return this.context.Reserva.Any(filter);
        }

        public List<Reservas> GetAll()
        {
            var reservas = this.context.Reserva.Select(reserva => new Reservas()
            {
                Id = reserva.Id,
                IdViaje = reserva.IdViaje,
                IdPasajero = reserva.IdPasajero,
                AsientosReservados = reserva.AsientosReservados,
                MontoTotal = reserva.MontoTotal,
                FechaCreacion = reserva.FechaCreacion
            }).ToList();

            this.logger.LogInformation("{Count} reservas encontradas", reservas.Count);
            return reservas;
        }

        public Reservas GetEntityBy(int id)
        {
            var reserva = GetReservaId(id);
            this.logger.LogInformation("Reserva encontrada: {ReservaId}", reserva.Id);
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
            var reservas = this.context.Reserva.Where(r => r.Id == IdReserva).Select(reserva => new Reservas()
            {
                Id = reserva.Id,
                IdViaje = reserva.IdViaje,
                IdPasajero = reserva.IdPasajero,
                AsientosReservados = reserva.AsientosReservados,
                MontoTotal = reserva.MontoTotal,
                FechaCreacion = reserva.FechaCreacion
            }).ToList();

            this.logger.LogInformation("{Count} reservas encontradas con ID: {IdReserva}", reservas.Count, IdReserva);
            return reservas;
        }

        private Reservas GetReservaId(int idReserva)
        {
            var reserva = this.context.Reserva.Find(idReserva);
            if (reserva == null)
            {
                this.logger.LogWarning("Reserva no encontrada: {IdReserva}", idReserva);
                throw new ReservaException("Reserva no encontrada");
            }
            return reserva;
        }
    }
}
