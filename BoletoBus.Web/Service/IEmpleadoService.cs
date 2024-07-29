using BoletoBus.Empleado.Application.Dtos;
using BoletoBus.Web.Models.EmpleadosModels;

namespace BoletoBus.Web.Service
{
    public interface IEmpleadoService
    {
        Task<EmpleadoGetListResult> GetEmpleados();
        Task<EmpleadoGetResult> GetEmpleadoById(int id);
        Task<EmpleadoGuardarResult> GuardarEmpleado(EmpleadosGuardar empleadoGuardar);
        Task<EmpleadoEditarGetResult> ActualizarEmpleado(EmpleadosEditar empleadoActualizar);
    }
}
