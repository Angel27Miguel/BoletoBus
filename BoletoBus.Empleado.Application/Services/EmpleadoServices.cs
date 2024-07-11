using BoletoBus.Empleado.Application.Base;
using BoletoBus.Empleado.Application.Dtos;
using BoletoBus.Empleado.Application.Interfaces;
using BoletoBus.Empleado.Domain.Entities;
using BoletoBus.Empleado.Domain.Interfaces;
using Microsoft.Extensions.Logging;


namespace BoletoBus.Empleado.Application.Services
{
    public class EmpleadoServices : IEmpleadoServices
    {
        private readonly ILogger<EmpleadoServices> logger;
        private readonly IEmpleadoRepository empleadoRepository;

        public EmpleadoServices(IEmpleadoRepository empleadoRepository, ILogger<EmpleadoServices> logger)
        {
            this.logger = logger;
            this.empleadoRepository = empleadoRepository;
        }

        private ServiceResult ValidarEmpleado(object empleado)
        {
            ServiceResult result = new ServiceResult();

            if (empleado is null)
            {
                result.Success = false;
                result.Message = "El empleado no puede ser nulo.";
                return result;
            }

            if (empleado is EmpleadosEditar editarModel)
            {
                return ValidarCamposEmpleado(editarModel.Nombre, editarModel.Cargo);
            }
            else if (empleado is EmpleadosGuardar guardarModel)
            {
                return ValidarCamposEmpleado(guardarModel.Nombre, guardarModel.Cargo);
            }

            return result;
        }

        private ServiceResult ValidarCamposEmpleado(string nombre, string cargo)
        {
            ServiceResult result = new ServiceResult();

            if (string.IsNullOrEmpty(nombre))
            {
                result.Success = false;
                result.Message = "El nombre del empleado es requerido.";
                return result;
            }

            if (nombre.Length > 100)
            {
                result.Success = false;
                result.Message = "El nombre del empleado debe ser menor de 100 caracteres.";
                return result;
            }

            if (cargo.Length > 50)
            {
                result.Success = false;
                result.Message = "El cargo del empleado debe ser menor de 50 caracteres.";
                return result;
            }

            return result;
        }

        public ServiceResult GetEmpleados()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = empleadoRepository.GetAll();
                this.logger.LogInformation("Empleados obtenidos exitosamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los empleados";
                this.logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult GetEmpleado(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this.empleadoRepository.GetEntityBy(id);
                this.logger.LogInformation($"Empleado con ID {id} obtenido exitosamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error obteniendo los datos";
                this.logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult EditarEmpleado(EmpleadosEditar empleadoEditar)
        {
            ServiceResult result = ValidarEmpleado(empleadoEditar);

            if (!result.Success)
                return result;

            try
            {
                Empleados empleado = new Empleados
                {
                    Id = empleadoEditar.IdEmpleado,
                    Nombre = empleadoEditar.Nombre,
                    Cargo = empleadoEditar.Cargo
                };

                this.empleadoRepository.Editar(empleado);
                this.logger.LogInformation($"Empleado con ID {empleadoEditar.IdEmpleado} editado exitosamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error editando los datos";
                this.logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult EliminarEmpleado(EmpleadosEliminar empleadoEliminar)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (empleadoEliminar is null)
                {
                    result.Success = false;
                    result.Message = "El modelo de eliminación no puede ser nulo.";
                    return result;
                }

                Empleados empleado = new Empleados
                {
                    Id = empleadoEliminar.IdEmpleado
                };

                this.empleadoRepository.Eliminar(empleado);
                this.logger.LogInformation($"Empleado con ID {empleadoEliminar.IdEmpleado} eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error eliminando los datos";
                this.logger.LogError(ex, result.Message);
            }
            return result;
        }

        public ServiceResult GuardarEmpleado(EmpleadosGuardar empleadoGuardar)
        {
            ServiceResult result = ValidarEmpleado(empleadoGuardar);

            if (!result.Success)
                return result;

            try
            {
                Empleados empleado = new Empleados
                {
                    Nombre = empleadoGuardar.Nombre,
                    Cargo = empleadoGuardar.Cargo
                };

                this.empleadoRepository.Agregar(empleado);
                this.logger.LogInformation($"Empleado guardado exitosamente.");
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error guardando los datos";
                this.logger.LogError(ex, result.Message);
            }
            return result;
        }
    }
}
