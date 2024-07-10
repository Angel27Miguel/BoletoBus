

using BoletoBus.Empleado.Application.Base;
using BoletoBus.Empleado.Application.Dtos;

namespace BoletoBus.Empleado.Application.Interfaces
{
    public interface IEmpleadoServices
    {
        ServiceResult GetEmpleados();
        ServiceResult GetEmpleado(int id);

        ServiceResult EditarEmpleado(EmpleadosEditarModel empleadoEditar);

        ServiceResult EliminarEmpleado(EmpleadosEliminarModel empleadoEliminar);

        ServiceResult GuardarEmpleado(EmpleadosGuardarModel empleadoGuardar);
    }
}
