using BoletoBus.Reserva.Application.Dtos;
using BoletoBus.Web.Models.Reserva;

namespace BoletoBus.Web.Service.Reserva
{
    public interface IReservaService
    {
        Task<ReservaGetListResult> GetReservas();
        Task<ReservaGetDetailsResult> GetReservaById(int id);
        Task<ReservaGuardarResult> GuardarReserva(ReservaGuardar reservaGuardar);
        Task<ReservaEditarGetResult> ActualizarReserva(ReservaEditar reservaActualizar);
    }
}
