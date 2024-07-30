using BoletoBus.Viaje.Application.Dtos;
using BoletoBus.Web.Models.ViajesModels;

namespace BoletoBus.Web.Service.Viaje
{
    public interface IViajeServices
    {
        Task<ViajeGetListResult> GetViajes();
        Task<ViajeGetDetailsResult> GetViajeaById(int id);
        Task<ViajeGuardarResult> GuardarViaje(ViajeGuardar viajeGuardar);
        Task<ViajeEditarGetResult> ActualizarViaje(ViajeEditar viajeEditar);
    }
}
