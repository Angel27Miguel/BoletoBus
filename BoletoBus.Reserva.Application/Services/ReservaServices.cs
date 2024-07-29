using BoletoBus.Common;
using BoletoBus.Reserva.Application.Dtos;
using BoletoBus.Reserva.Application.Interfaces;
using BoletoBus.Reserva.Domain.Entities;
using BoletoBus.Reserva.Domain.Interfaces;
using Microsoft.Extensions.Logging;

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

        private ServiceResult<string> ValidarReserva(object reserva)
        {
            var result = new ServiceResult<string>();

            if (reserva == null)
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

        private ServiceResult<string> ValidarCamposReserva(int IdViaje, int IdPasajero, int AsientosReservados, decimal MontoTotal)
        {
            var result = new ServiceResult<string>();

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

        public ServiceResult<List<ReservaMode>> GetReserva()
        {
            var result = new ServiceResult<List<ReservaMode>>();

            try
            {
                var reservas = reservaRepository.GetAll();
                result.Data = reservas.Select(r => new ReservaMode
                {
                    IdReserva = r.Id,
                    IdViaje = r.IdViaje,
                    IdPasajero = r.IdPasajero,
                    AsientosReservados = r.AsientosReservados,
                    MontoTotal = r.MontoTotal
                }).ToList();

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

        public ServiceResult<ReservaMode> GetReservaById(int id)
        {
            var result = new ServiceResult<ReservaMode>();

            try
            {
                var reserva = this.reservaRepository.GetEntityBy(id);
                result.Data = new ReservaMode
                {
                    IdReserva = reserva.Id,
                    IdViaje = reserva.IdViaje,
                    IdPasajero = reserva.IdPasajero,
                    AsientosReservados = reserva.AsientosReservados,
                    MontoTotal = reserva.MontoTotal
                };

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

        public ServiceResult<bool> GuardarReserva(ReservaGuardar guardarReserva)
        {
            var result = ValidarReserva(guardarReserva);

            if (!result.Success)
                return new ServiceResult<bool> { Success = false, Message = result.Message };

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

                this.reservaRepository.Agregar(reserva);
                this.logger.LogInformation("Reserva guardada exitosamente.");

                return new ServiceResult<bool> { Data = true };
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Ocurrió un error guardando los datos");
                return new ServiceResult<bool> { Success = false, Message = "Ocurrió un error guardando los datos" };
            }
        }

        public ServiceResult<bool> EditarReserva(ReservaEditar editarReserva)
        {
            var result = ValidarReserva(editarReserva);

            if (!result.Success)
                return new ServiceResult<bool> { Success = false, Message = result.Message };

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

                this.reservaRepository.Editar(reserva);
                this.logger.LogInformation($"Reserva con ID {editarReserva.IdReserva} editada exitosamente.");

                return new ServiceResult<bool> { Data = true };
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Ocurrió un error editando los datos");
                return new ServiceResult<bool> { Success = false, Message = "Ocurrió un error editando los datos" };
            }
        }

        public ServiceResult<bool> EliminarReserva(ReservaEliminar eliminarReserva)
        {
            var result = new ServiceResult<bool>();

            try
            {
                if (eliminarReserva == null)
                {
                    result.Success = false;
                    result.Message = "La reserva no puede ser nula.";
                    return result;
                }

                var reserva = new Reservas
                {
                    Id = eliminarReserva.IdReserva
                };

                this.reservaRepository.Eliminar(reserva);
                this.logger.LogInformation($"Reserva con ID {eliminarReserva.IdReserva} eliminada exitosamente.");

                return new ServiceResult<bool> { Data = true };
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error eliminando los datos";
                this.logger.LogError(ex, result.Message);
            }

            return result;
        }
    }
}
