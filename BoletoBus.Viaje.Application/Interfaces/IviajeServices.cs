

using BoletoBus.Viaje.Application.Base;
using BoletoBus.Viaje.Application.Dtos;

namespace BoletoBus.Viaje.Application.Interfaces
{
    public interface  IviajeServices
    {
       
        ServiceResult GetViajes();
        ServiceResult GetViaje(int id);
        ServiceResult EditarViaje(ViajeEditarModel viajeEditar);

        ServiceResult EliminarViaje(ViajeEliminarModel viajeEliminar);

        ServiceResult GuardarViaje(ViajeGuardarModel viajeGuardar);

    }
}
