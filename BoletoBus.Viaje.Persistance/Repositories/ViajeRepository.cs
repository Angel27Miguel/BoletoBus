using BoletoBus.Viaje.Domain.Entities;
using BoletoBus.Viaje.Domain.Interfaces;
using BoletoBus.Viaje.Persistance.Context;
using BoletoBus.Viaje.Persistance.Exceptions;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace BoletoBus.Viaje.Persistance.Repositories
{
    public class ViajeRepository : IViajeRepository
    {
        private readonly BoletoBusContext context;
        private readonly ILogger<ViajeRepository> logger;

        public ViajeRepository(BoletoBusContext context, ILogger<ViajeRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public void Agregar(Domain.Entities.Viaje entity)
        {
            Domain.Entities.Viaje viaje = new()
            {
                IdBus = entity.IdBus,
                IdRuta = entity.IdRuta,
                FechaSalida = entity.FechaSalida,
                HoraSalida = entity.HoraSalida,
                FechaLlegada = entity.FechaLlegada,
                HoraLlegada = entity.HoraLlegada,
                Precio = entity.Precio,
                TotalAsientos = entity.TotalAsientos,
                AsientosReservados = entity.AsientosReservados,
                FechaCreacion = entity.FechaCreacion
            };

            this.context.Add(viaje);
            this.context.SaveChanges();
            this.logger.LogInformation("Viaje agregado: {ViajeId}", viaje.Id);
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

            this.context.Update(viaje);
            this.context.SaveChanges();
            this.logger.LogInformation("Viaje editado: {ViajeId}", viaje.Id);
        }

        public void Eliminar(Domain.Entities.Viaje entity)
        {
            var viaje = GetViajeById(entity.Id);

            this.context.Viaje.Remove(viaje);
            this.context.SaveChanges();
            this.logger.LogInformation("Viaje eliminado: {ViajeId}", viaje.Id);
        }

        public bool Exists(Expression<Func<Domain.Entities.Viaje, bool>> filter)
        {
            return this.context.Viaje.Any(filter);
        }

        public List<Domain.Entities.Viaje> GetAll()
        {
            var viajes = this.context.Viaje.Select(viaje => new Domain.Entities.Viaje()
            {
                Id = viaje.Id,
                IdBus = viaje.IdBus,
                IdRuta = viaje.IdRuta,
                FechaSalida = viaje.FechaSalida,
                HoraSalida = viaje.HoraSalida,
                FechaLlegada = viaje.FechaLlegada,
                HoraLlegada = viaje.HoraLlegada,
                Precio = viaje.Precio,
                TotalAsientos = viaje.TotalAsientos,
                AsientosReservados = viaje.AsientosReservados,
                AsientoDisponibles = viaje.AsientoDisponibles, 
                FechaCreacion = viaje.FechaCreacion
            }).ToList();

            this.logger.LogInformation("{Count} viajes encontrados", viajes.Count);
            return viajes;
        }

        public Domain.Entities.Viaje GetEntityBy(int id)
        {
            var viaje = GetViajeById(id);
            this.logger.LogInformation("Viaje encontrado: {ViajeId}", viaje.Id);
            return new Domain.Entities.Viaje()
            {
                Id = viaje.Id,
                IdBus = viaje.IdBus,
                IdRuta = viaje.IdRuta,
                FechaSalida = viaje.FechaSalida,
                HoraSalida = viaje.HoraSalida,
                FechaLlegada = viaje.FechaLlegada,
                HoraLlegada = viaje.HoraLlegada,
                Precio = viaje.Precio,
                TotalAsientos = viaje.TotalAsientos,
                AsientosReservados = viaje.AsientosReservados,
                AsientoDisponibles = viaje.AsientoDisponibles, 
                FechaCreacion = viaje.FechaCreacion
            };
        }

        public List<Domain.Entities.Viaje> GetViajesByID(int idViaje)
        {
            var viajes = this.context.Viaje.Where(v => v.Id == idViaje).Select(viaje => new Domain.Entities.Viaje()
            {
                Id = viaje.Id,
                IdBus = viaje.IdBus,
                IdRuta = viaje.IdRuta,
                FechaSalida = viaje.FechaSalida,
                HoraSalida = viaje.HoraSalida,
                FechaLlegada = viaje.FechaLlegada,
                HoraLlegada = viaje.HoraLlegada,
                Precio = viaje.Precio,
                TotalAsientos = viaje.TotalAsientos,
                AsientosReservados = viaje.AsientosReservados,
                AsientoDisponibles = viaje.AsientoDisponibles, 
                FechaCreacion = viaje.FechaCreacion
            }).ToList();

            this.logger.LogInformation("{Count} viajes encontrados con ID: {IdViaje}", viajes.Count, idViaje);
            return viajes;
        }

        private Domain.Entities.Viaje GetViajeById(int idViaje)
        {
            var viaje = this.context.Viaje.Find(idViaje);
            if (viaje == null)
            {
                this.logger.LogWarning("Viaje no encontrado: {IdViaje}", idViaje);
                throw new ViajeException("Viaje no encontrado");
            }
            return viaje;
        }
    }
}
