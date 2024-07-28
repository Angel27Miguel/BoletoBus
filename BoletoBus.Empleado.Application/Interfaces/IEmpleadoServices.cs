using BoletoBus.Empleado.Application.Base;
using BoletoBus.Empleado.Application.Dtos;

namespace BoletoBus.Empleado.Application.Interfaces
{
    public interface IEmpleadoServices
    {
        ServiceResult<List<EmpleadoGetModel>> GetEmpleados();
        ServiceResult<EmpleadoGetModel> GetEmpleado(int id);
        ServiceResult<bool> EditarEmpleado(EmpleadosEditar empleadoEditar);
        ServiceResult<bool> EliminarEmpleado(EmpleadosEliminar empleadoEliminar);
        ServiceResult<bool> GuardarEmpleado(EmpleadosGuardar empleadoGuardar);
    }
}
