using BoletoBus.Viaje.Application.Base;
using BoletoBus.Viaje.Application.Dtos;
using BoletoBus.Viaje.Application.Interfaces;
using BoletoBus.Viaje.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;

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

        public ServiceResult EditarViaje(ViajeEditarModel viajeEditar)
        {
            var result = ValidarViaje(viajeEditar);

            if (!result.Success)
                return result;

            try
            {
                var entity = viajeRepository.GetEntityBy(viajeEditar.IdViaje);
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
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error editando los datos";
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult EliminarViaje(ViajeEliminarModel viajeEliminar)
        {
            var result = new ServiceResult();

            try
            {
                if (viajeEliminar is null)
                {
                    result.Success = false;
                    result.Message = "El viaje no puede ser nulo.";
                    return result;
                }

                var entity = viajeRepository.GetEntityBy(viajeEliminar.IdViaje);
                viajeRepository.Eliminar(entity);
                logger.LogInformation($"Viaje con ID {viajeEliminar.IdViaje} eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error eliminando los datos";
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult GetViaje(int id)
        {
            var result = new ServiceResult();
            try
            {
                result.Data = viajeRepository.GetEntityBy(id);
                logger.LogInformation($"Viaje con ID {id} obtenido exitosamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los datos";
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult GetViajes()
        {
            var result = new ServiceResult();
            try
            {
                result.Data = viajeRepository.GetAll();
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

        public ServiceResult GuardarViaje(ViajeGuardarModel viajeGuardar)
        {
            var result = ValidarViaje(viajeGuardar);

            if (!result.Success)
                return result;

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
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error guardando los datos";
                logger.LogError(ex, result.Message);
            }
            return result;
        }

        private ServiceResult ValidarViaje(object viaje)
        {
            var result = new ServiceResult();

            if (viaje is null)
            {
                result.Success = false;
                result.Message = "El viaje no puede ser nulo.";
                return result;
            }

            if (viaje is ViajeEditarModel editarModel)
            {
                return ValidarCamposViaje(editarModel.IdBus, editarModel.IdRuta, editarModel.HoraSalida, editarModel.HoraLlegada, editarModel.Precio, editarModel.TotalAsientos, editarModel.AsientosReservados);
            }
            else if (viaje is ViajeGuardarModel guardarModel)
            {
                return ValidarCamposViaje(guardarModel.IdBus, guardarModel.IdRuta, guardarModel.HoraSalida, guardarModel.HoraLlegada, guardarModel.Precio, guardarModel.TotalAsientos, guardarModel.AsientosReservados);
            }

            return result;
        }

        private ServiceResult ValidarCamposViaje(int IdBus, int IdRuta, TimeSpan HoraSalida, TimeSpan HoraLlegada, decimal Precio, int TotalAsientos, int AsientosReservados)
        {
            var result = new ServiceResult();

            if (IdBus <= 0)
            {
                result.Success = false;
                result.Message = "El ID del bus es requerido.";
                return result;
            }

            if (IdRuta <= 0)
            {
                result.Success = false;
                result.Message = "El ID de la ruta es requerido.";
                return result;
            }

            if (TotalAsientos <= 0)
            {
                result.Success = false;
                result.Message = "El total de asientos es requerido.";
                return result;
            }

            if (AsientosReservados < 0)
            {
                result.Success = false;
                result.Message = "Los asientos reservados no pueden ser negativos.";
                return result;
            }

            if (HoraSalida.TotalHours > 99999.99 || HoraSalida.TotalHours < 0)
            {
                result.Success = false;
                result.Message = "La hora de salida debe ser un valor válido.";
                return result;
            }

            if (HoraLlegada.TotalHours > 99999.99 || HoraLlegada.TotalHours < 0)
            {
                result.Success = false;
                result.Message = "La hora de llegada debe ser un valor válido.";
                return result;
            }

            if (Precio < 0 || Precio > 9999999.99m)
            {
                result.Success = false;
                result.Message = "El precio debe ser un valor válido.";
                return result;
            }

            return result;
        }
    }
}
