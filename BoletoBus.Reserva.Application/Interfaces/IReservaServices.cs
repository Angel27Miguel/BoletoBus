
using BoletoBus.Reserva.Application.Base;
using BoletoBus.Reserva.Application.Dtos;

namespace BoletoBus.Reserva.Application.Interfaces
{
    public interface  IReservaServices
    {
        ServiceResult GetReserva();
        ServiceResult GetReservaById(int Id);
        ServiceResult GuardarReserva(ReservaGuardar guardarReserva);
        ServiceResult EditarReserva(ReservaEditar editarReserva);
        ServiceResult EliminarReserva(ReservaEliminar eliminarReserva);

    }
}
