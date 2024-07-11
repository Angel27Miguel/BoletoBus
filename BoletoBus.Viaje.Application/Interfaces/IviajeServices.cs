

using BoletoBus.Viaje.Application.Base;
using BoletoBus.Viaje.Application.Dtos;

namespace BoletoBus.Viaje.Application.Interfaces
{
    public interface  IviajeServices
    {
       
        ServiceResult GetViajes();
        ServiceResult GetViaje(int id);
        ServiceResult EditarViaje(ViajeEditar viajeEditar);

        ServiceResult EliminarViaje(ViajeEliminar viajeEliminar);

        ServiceResult GuardarViaje(ViajeGuardar viajeGuardar);

    }
}
