using System.Linq.Expressions;
using BoletoBus.Viaje.Domain.Interfaces;
using BoletoBus.Viaje.Persistance.Context;
using BoletoBus.Viaje.Persistance.Exceptions;
using Microsoft.Extensions.Logging;

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

        private Domain.Entities.Viaje GetViajeById(int idViaje)
        {
            logger.LogInformation($"Obteniendo viaje por ID: {idViaje}");
            var viaje = this.context.Viaje.Find(idViaje);
            if (viaje == null)
            {
                logger.LogWarning($"Viaje no encontrado: {idViaje}");
                throw new ViajeException("Viaje no encontrado");
            }
            return viaje;
        }

        public void Agregar(Domain.Entities.Viaje entity)
        {
            logger.LogInformation($"Agregando nuevo viaje: {entity}");
            this.context.Viaje.Add(entity);
            this.context.SaveChanges();
            logger.LogInformation($"Viaje agregado con éxito: {entity.Id}");
        }

        public void Editar(Domain.Entities.Viaje entity)
        {
            logger.LogInformation($"Editando viaje: {entity.Id}");
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
            logger.LogInformation($"Viaje editado con éxito: {entity.Id}");
        }

        public void Eliminar(Domain.Entities.Viaje entity)
        {
            logger.LogInformation($"Eliminando viaje: {entity.Id}");
            var viaje = GetViajeById(entity.Id);

            this.context.Viaje.Remove(viaje);
            this.context.SaveChanges();
            logger.LogInformation($"Viaje eliminado con éxito: {entity.Id}");
        }

        public bool Exists(Expression<Func<Domain.Entities.Viaje, bool>> filter)
        {
            logger.LogInformation("Verificando si existe el viaje con el filtro especificado");
            return this.context.Viaje.Any(filter);
        }

        public List<Domain.Entities.Viaje> GetAll()
        {
            logger.LogInformation("Obteniendo todos los viajes");
            return this.context.Viaje.OrderByDescending(v => v.FechaCreacion).ToList();
        }

        public Domain.Entities.Viaje GetEntityBy(int id)
        {
            logger.LogInformation($"Obteniendo viaje por ID: {id}");
            return GetViajeById(id);
        }

        public List<Domain.Entities.Viaje> GetViajesByID(int idViaje)
        {
            logger.LogInformation($"Obteniendo viajes por ID: {idViaje}");
            return this.context.Viaje.Where(v => v.Id == idViaje).ToList();
        }
    }
}
