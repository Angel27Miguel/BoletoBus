using BoletoBus.Common;
using BoletoBus.Viaje.Application.Dtos;

namespace BoletoBus.Viaje.Application.Interfaces
{
    public interface IviajeServices
    {
        ServiceResult<List<ViajeMode>> GetViajes();
        ServiceResult<ViajeMode> GetViaje(int id);
        ServiceResult<bool> EditarViaje(ViajeEditar viajeEditar);
        ServiceResult<bool> EliminarViaje(ViajeEliminar viajeEliminar);
        ServiceResult<bool> GuardarViaje(ViajeGuardar viajeGuardar);
    }
}
