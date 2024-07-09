

using BoletoBus.Empleado.Application.Dtos;

namespace BoletoBus.Empleado.Application.Interfaces
{
    internal interface IEmpleadoServices
    {
        List<EmpleadoModel> GetEmpleados();

        void GuardarEmpleado(EmpleadosGuardarModel empleadosGuardar);

        void EliminarEmpleados(EmpleadosEliminarModel empleadosEliminar);

        void EditarEmpleados(EmpleadosEditarModel empleadosEditar);


        EmpleadoModel GetEmpleado(int IdEmpleado);
    }
}
