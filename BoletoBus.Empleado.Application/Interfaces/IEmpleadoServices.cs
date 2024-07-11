

using BoletoBus.Empleado.Application.Base;
using BoletoBus.Empleado.Application.Dtos;

namespace BoletoBus.Empleado.Application.Interfaces
{
    public interface IEmpleadoServices
    {
        ServiceResult GetEmpleados();
        ServiceResult GetEmpleado(int id);

        ServiceResult EditarEmpleado(EmpleadosEditar empleadoEditar);

        ServiceResult EliminarEmpleado(EmpleadosEliminar empleadoEliminar);

        ServiceResult GuardarEmpleado(EmpleadosGuardar empleadoGuardar);
    }
}
