using BoletoBus.Reserva.Application.Base;
using BoletoBus.Reserva.Application.Dtos;
using BoletoBus.Reserva.Application.Interfaces;
using BoletoBus.Reserva.Domain.Entities;
using BoletoBus.Reserva.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;

namespace BoletoBus.Reserva.Application.Services
{
    public class ReservaServices : IReservaServices
    {
        private readonly IReservaRepository reservaRepository;
        private readonly ILogger<ReservaServices> logger;

        public ReservaServices(IReservaRepository reservaRepository, ILogger<ReservaServices> logger)
        {
            this.reservaRepository = reservaRepository;
            this.logger = logger;
        }

        public ServiceResult GetReserva()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = reservaRepository.GetAll();
                this.logger.LogInformation("Reservas obtenidas exitosamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo las reservas";
                this.logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult GetReservaById(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = reservaRepository.GetEntityBy(id);
                this.logger.LogInformation($"Reserva con ID {id} obtenida exitosamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los datos";
                this.logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult EditarReserva(ReservaEditar editarReserva)
        {
            ServiceResult result = ValidarReserva(editarReserva);

            if (!result.Success)
                return result;

            try
            {
                var reserva = new Reservas
                {
                    Id = editarReserva.IdReserva,
                    IdViaje = editarReserva.IdViaje,
                    IdPasajero = editarReserva.IdPasajero,
                    AsientosReservados = editarReserva.AsientosReservados,
                    MontoTotal = editarReserva.MontoTotal
                };

                reservaRepository.Editar(reserva);
                this.logger.LogInformation($"Reserva con ID {editarReserva.IdReserva} editada exitosamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error editando los datos";
                this.logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult EliminarReserva(ReservaEliminar eliminarReserva)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (eliminarReserva is null)
                {
                    result.Success = false;
                    result.Message = "La reserva no puede ser nula.";
                    return result;
                }

                var reserva = new Reservas
                {
                    Id = eliminarReserva.IdReserva
                };

                reservaRepository.Eliminar(reserva);
                this.logger.LogInformation($"Reserva con ID {eliminarReserva.IdReserva} eliminada exitosamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error eliminando los datos";
                this.logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult GuardarReserva(ReservaGuardar guardarReserva)
        {
            ServiceResult result = ValidarReserva(guardarReserva);

            if (!result.Success)
                return result;

            try
            {
                var reserva = new Reservas
                {
                    IdViaje = guardarReserva.IdViaje,
                    IdPasajero = guardarReserva.IdPasajero,
                    AsientosReservados = guardarReserva.AsientosReservados,
                    MontoTotal = guardarReserva.MontoTotal,
                    FechaCreacion = guardarReserva.FechaCreacion
                };

                reservaRepository.Agregar(reserva);
                this.logger.LogInformation($"Reserva guardada exitosamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error guardando los datos";
                this.logger.LogError(ex, result.Message);
            }
            return result;
        }

        private ServiceResult ValidarReserva(object reserva)
        {
            ServiceResult result = new ServiceResult();

            if (reserva is null)
            {
                result.Success = false;
                result.Message = "La reserva no puede ser nula.";
                return result;
            }

            if (reserva is ReservaEditar editarModel)
            {
                return ValidarCamposReserva(editarModel.IdViaje, editarModel.IdPasajero, editarModel.AsientosReservados, editarModel.MontoTotal);
            }
            else if (reserva is ReservaGuardar guardarModel)
            {
                return ValidarCamposReserva(guardarModel.IdViaje, guardarModel.IdPasajero, guardarModel.AsientosReservados, guardarModel.MontoTotal);
            }

            return result;
        }

        private ServiceResult ValidarCamposReserva(int IdViaje, int IdPasajero, int AsientosReservados, decimal MontoTotal)
        {
            ServiceResult result = new ServiceResult();

            if (IdViaje <= 0)
            {
                result.Success = false;
                result.Message = "El ID del viaje es requerido.";
                return result;
            }

            if (IdPasajero <= 0)
            {
                result.Success = false;
                result.Message = "El ID del pasajero es requerido.";
                return result;
            }

            if (AsientosReservados < 0)
            {
                result.Success = false;
                result.Message = "Los asientos reservados no pueden ser negativos.";
                return result;
            }

            if (MontoTotal < 0 || MontoTotal > 99999999.99m)
            {
                result.Success = false;
                result.Message = "El monto total debe ser un valor válido.";
                return result;
            }

            return result;
        }
    }
}
