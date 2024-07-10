﻿using BoletoBus.Empleado.Application.Base;
using BoletoBus.Empleado.Application.Dtos;
using BoletoBus.Empleado.Application.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus.Empleado.Application.Services
{
    public class EmpleadoServices : IEmpleadoServices
    {
        private readonly ILogger<EmpleadoServices> logger;
        private readonly IEmpleados empleadoDb;

        public EmpleadoServices(IEmpleados empleadoDb, ILogger<EmpleadoServices> logger)
        {
            this.logger = logger;
            this.empleadoDb = empleadoDb;
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

            if (empleado is EmpleadosEditarModel editarModel)
            {
                return ValidarCamposEmpleado(editarModel.Nombre, editarModel.Cargo);
            }
            else if (empleado is EmpleadosGuardarModel guardarModel)
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

        ServiceResult IEmpleadoServices.GetEmpleados()
        {
            ServiceResult result = new ServiceResult();

            try
            {
                result.Data = empleadoDb.GetEmpleados();
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

        ServiceResult IEmpleadoServices.GetEmpleado(int id)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = this.empleadoDb.GetEmpleado(id);
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

        ServiceResult IEmpleadoServices.EditarEmpleado(EmpleadosEditarModel empleadoEditar)
        {
            ServiceResult result = ValidarEmpleado(empleadoEditar);

            if (!result.Success)
                return result;

            try
            {
                this.empleadoDb.EditarEmpleados(empleadoEditar);
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

        ServiceResult IEmpleadoServices.EliminarEmpleado(EmpleadosEliminarModel empleadoEliminar)
        {
            ServiceResult result = new ServiceResult();

            try
            {
                if (empleadoEliminar is null)
                {
                    result.Success = false;
                    result.Message = "";
                    return result;
                }
                this.empleadoDb.EliminarEmpleados(empleadoEliminar);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = "Ocurrió un error eliminando los datos";
                this.logger.LogError(ex, result.Message);
            }
            return result;
        }

        ServiceResult IEmpleadoServices.GuardarEmpleado(EmpleadosGuardarModel empleadoGuardar)
        {
            ServiceResult result = ValidarEmpleado(empleadoGuardar);

            if (!result.Success)
                return result;

            try
            {
                this.empleadoDb.GuardarEmpleado(empleadoGuardar);
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