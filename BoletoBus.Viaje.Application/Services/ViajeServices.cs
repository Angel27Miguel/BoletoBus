using BoletoBus.Common;
using BoletoBus.Viaje.Application.Dtos;
using BoletoBus.Viaje.Application.Interfaces;
using BoletoBus.Viaje.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BoletoBus.Viaje.Application.Services
{
    public class ViajeServices : IviajeServices
    {
        private readonly IViajeRepository viajeRepository;
        private readonly ILogger<ViajeServices> logger;

        public ViajeServices(IViajeRepository viajeRepository, ILogger<ViajeServices> logger)
        {
            this.viajeRepository = viajeRepository;
            this.logger = logger;
        }

        public ServiceResult<List<ViajeMode>> GetViajes()
        {
            var result = new ServiceResult<List<ViajeMode>>();

            try
            {
                var viajes = viajeRepository.GetAll();
                result.Data = viajes.Select(v => new ViajeMode
                {
                    IdViaje = v.Id,
                    IdBus = v.IdBus,
                    IdRuta = v.IdRuta,
                    FechaSalida = v.FechaSalida,
                    HoraSalida = v.HoraSalida,
                    FechaLlegada = v.FechaLlegada,
                    HoraLlegada = v.HoraLlegada,
                    Precio = v.Precio,
                    TotalAsientos = v.TotalAsientos,
                    AsientosReservados = v.AsientosReservados
                }).ToList();

                logger.LogInformation("Viajes obtenidos exitosamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los viajes";
                logger.LogError(ex, result.Message);
            }

            return result;
        }

        public ServiceResult<ViajeMode> GetViaje(int id)
        {
            var result = new ServiceResult<ViajeMode>();

            try
            {
                var viaje = viajeRepository.GetEntityBy(id);
                if (viaje != null)
                {
                    result.Data = new ViajeMode
                    {
                        IdViaje = viaje.Id,
                        IdBus = viaje.IdBus,
                        IdRuta = viaje.IdRuta,
                        FechaSalida = viaje.FechaSalida,
                        HoraSalida = viaje.HoraSalida,
                        FechaLlegada = viaje.FechaLlegada,
                        HoraLlegada = viaje.HoraLlegada,
                        Precio = viaje.Precio,
                        TotalAsientos = viaje.TotalAsientos,
                        AsientosReservados = viaje.AsientosReservados
                    };

                    logger.LogInformation($"Viaje con ID {id} obtenido exitosamente.");
                }
                else
                {
                    result.Success = false;
                    result.Message = "Viaje no encontrado.";
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo el viaje";
                logger.LogError(ex, result.Message);
            }

            return result;
        }

        public ServiceResult<bool> EditarViaje(ViajeEditar viajeEditar)
        {
            var result = new ServiceResult<bool>();

            if (viajeEditar == null)
            {
                result.Success = false;
                result.Message = "El modelo de edición no puede ser nulo.";
                return result;
            }

            try
            {
                var entity = viajeRepository.GetEntityBy(viajeEditar.IdViaje);
                if (entity == null)
                {
                    result.Success = false;
                    result.Message = "Viaje no encontrado.";
                    return result;
                }

                entity.IdBus = viajeEditar.IdBus;
                entity.IdRuta = viajeEditar.IdRuta;
                entity.FechaSalida = viajeEditar.FechaSalida;
                entity.HoraSalida = viajeEditar.HoraSalida;
                entity.FechaLlegada = viajeEditar.FechaLlegada;
                entity.HoraLlegada = viajeEditar.HoraLlegada;
                entity.Precio = viajeEditar.Precio;
                entity.TotalAsientos = viajeEditar.TotalAsientos;
                entity.AsientosReservados = viajeEditar.AsientosReservados;

                viajeRepository.Editar(entity);
                logger.LogInformation($"Viaje con ID {viajeEditar.IdViaje} editado exitosamente.");
                result.Data = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error editando los datos";
                logger.LogError(ex, result.Message);
            }

            return result;
        }

        public ServiceResult<bool> EliminarViaje(ViajeEliminar viajeEliminar)
        {
            var result = new ServiceResult<bool>();

            if (viajeEliminar == null)
            {
                result.Success = false;
                result.Message = "El modelo de eliminación no puede ser nulo.";
                return result;
            }

            try
            {
                var entity = viajeRepository.GetEntityBy(viajeEliminar.IdViaje);
                if (entity == null)
                {
                    result.Success = false;
                    result.Message = "Viaje no encontrado.";
                    return result;
                }

                viajeRepository.Eliminar(entity);
                logger.LogInformation($"Viaje con ID {viajeEliminar.IdViaje} eliminado exitosamente.");
                result.Data = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error eliminando los datos";
                logger.LogError(ex, result.Message);
            }

            return result;
        }

        public ServiceResult<bool> GuardarViaje(ViajeGuardar viajeGuardar)
        {
            var result = new ServiceResult<bool>();

            if (viajeGuardar == null)
            {
                result.Success = false;
                result.Message = "El modelo de guardado no puede ser nulo.";
                return result;
            }

            try
            {
                var entity = new Domain.Entities.Viaje
                {
                    IdBus = viajeGuardar.IdBus,
                    IdRuta = viajeGuardar.IdRuta,
                    FechaSalida = viajeGuardar.FechaSalida,
                    HoraSalida = viajeGuardar.HoraSalida,
                    FechaLlegada = viajeGuardar.FechaLlegada,
                    HoraLlegada = viajeGuardar.HoraLlegada,
                    Precio = viajeGuardar.Precio,
                    TotalAsientos = viajeGuardar.TotalAsientos,
                    AsientosReservados = viajeGuardar.AsientosReservados,
                    FechaCreacion = DateTime.Now
                };

                viajeRepository.Agregar(entity);
                logger.LogInformation("Viaje guardado exitosamente.");
                result.Data = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error guardando los datos";
                logger.LogError(ex, result.Message);
            }

            return result;
        }
    }
}
