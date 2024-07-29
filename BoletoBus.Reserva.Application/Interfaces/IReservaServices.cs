
using BoletoBus.Common;
using BoletoBus.Reserva.Application.Dtos;

namespace BoletoBus.Reserva.Application.Interfaces
{
    public interface  IReservaServices
    {
        ServiceResult <List<ReservaMode>>GetReserva();
        ServiceResult <ReservaMode> GetReservaById(int Id);
        ServiceResult<bool> GuardarReserva(ReservaGuardar guardarReserva);
        ServiceResult<bool> EditarReserva(ReservaEditar editarReserva);
        ServiceResult<bool> EliminarReserva(ReservaEliminar eliminarReserva);

    }
}
