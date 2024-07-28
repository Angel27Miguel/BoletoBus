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

        private ServiceResult<string> ValidarEmpleado(object empleado)
        {
            var result = new ServiceResult<string>();

            if (empleado == null)
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

        private ServiceResult<string> ValidarCamposEmpleado(string nombre, string cargo)
        {
            var result = new ServiceResult<string>();

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

        public ServiceResult<List<EmpleadoGetModel>> GetEmpleados()
        {
            var result = new ServiceResult<List<EmpleadoGetModel>>();

            try
            {
                var empleados = empleadoRepository.GetAll();
                result.Data = empleados.Select(e => new EmpleadoGetModel
                {
                    IdEmpleado = e.Id,
                    Nombre = e.Nombre,
                    Cargo = e.Cargo
                }).ToList();

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

        public ServiceResult<EmpleadoGetModel> GetEmpleado(int id)
        {
            var result = new ServiceResult<EmpleadoGetModel>();

            try
            {
                var empleado = this.empleadoRepository.GetEntityBy(id);
                result.Data = new EmpleadoGetModel
                {
                    IdEmpleado = empleado.Id,
                    Nombre = empleado.Nombre,
                    Cargo = empleado.Cargo
                };

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

        public ServiceResult<bool> EditarEmpleado(EmpleadosEditar empleadoEditar)
        {
            var result = ValidarEmpleado(empleadoEditar);

            if (!result.Success)
                return new ServiceResult<bool> { Success = false, Message = result.Message };

            try
            {
                var empleado = new Empleados
                {
                    Id = empleadoEditar.IdEmpleado,
                    Nombre = empleadoEditar.Nombre,
                    Cargo = empleadoEditar.Cargo
                };

                this.empleadoRepository.Editar(empleado);
                this.logger.LogInformation($"Empleado con ID {empleadoEditar.IdEmpleado} editado exitosamente.");

                return new ServiceResult<bool> { Data = true };
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Ocurrió un error editando los datos");
                return new ServiceResult<bool> { Success = false, Message = "Ocurrió un error editando los datos" };
            }
        }

        public ServiceResult<bool> EliminarEmpleado(EmpleadosEliminar empleadoEliminar)
        {
            var result = new ServiceResult<bool>();

            try
            {
                if (empleadoEliminar == null)
                {
                    result.Success = false;
                    result.Message = "El modelo de eliminación no puede ser nulo.";
                    return result;
                }

                var empleado = new Empleados
                {
                    Id = empleadoEliminar.IdEmpleado
                };

                this.empleadoRepository.Eliminar(empleado);
                this.logger.LogInformation($"Empleado con ID {empleadoEliminar.IdEmpleado} eliminado exitosamente.");

                result.Data = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error eliminando los datos";
                this.logger.LogError(ex, result.Message);
            }

            return result;
        }

        public ServiceResult<bool> GuardarEmpleado(EmpleadosGuardar empleadoGuardar)
        {
            var result = ValidarEmpleado(empleadoGuardar);

            if (!result.Success)
                return new ServiceResult<bool> { Success = false, Message = result.Message };

            try
            {
                var empleado = new Empleados
                {
                    Nombre = empleadoGuardar.Nombre,
                    Cargo = empleadoGuardar.Cargo
                };

                this.empleadoRepository.Agregar(empleado);
                this.logger.LogInformation("Empleado guardado exitosamente.");

                return new ServiceResult<bool> { Data = true };
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, "Ocurrió un error guardando los datos");
                return new ServiceResult<bool> { Success = false, Message = "Ocurrió un error guardando los datos" };
            }
        }
    }
}

