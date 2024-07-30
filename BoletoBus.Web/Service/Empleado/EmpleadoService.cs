using BoletoBus.Empleado.Application.Dtos;
using BoletoBus.Web.Models.EmpleadosModels;
using Newtonsoft.Json;

namespace BoletoBus.Web.Service.Empleado
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger<EmpleadoService> Logger;
        private readonly IHttpClientFactory ClientFactory;
        private readonly string BaseUrl;

        public EmpleadoService(IConfiguration configuration, ILogger<EmpleadoService> logger, IHttpClientFactory clientFactory)
        {
            Configuration = configuration;
            Logger = logger;
            ClientFactory = clientFactory;
            BaseUrl = Configuration["apiConfig:baseUrlEmpleado"];
        }

        public async Task<EmpleadoGetListResult> GetEmpleados()
        {
            var result = new EmpleadoGetListResult();
            try
            {
                using (var httpClient = ClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"{BaseUrl}GetEmpleado");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<EmpleadoGetListResult>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error obteniendo la lista de empleados");
                result.Success = false;
                result.Message = "Error obteniendo la lista de empleados.";
            }
            return result;
        }

        public async Task<EmpleadoGetDetailsResult> GetEmpleadoById(int id)
        {
            var result = new EmpleadoGetDetailsResult();
            try
            {
                using (var httpClient = ClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"{BaseUrl}GetEmpleadoById?id={id}");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<EmpleadoGetDetailsResult>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error obteniendo el empleado con ID {id}");
                result.Success = false;
                result.Message = $"Error obteniendo el empleado con ID {id}.";
            }
            return result;
        }

        public async Task<EmpleadoGuardarResult> GuardarEmpleado(EmpleadosGuardar empleadoGuardar)
        {
            var result = new EmpleadoGuardarResult();
            try
            {
                using (var httpClient = ClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(empleadoGuardar), System.Text.Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync($"{BaseUrl}GuardarEmpleado", content);
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<EmpleadoGuardarResult>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error guardando el empleado");
                result.Success = false;
                result.Message = "Error guardando el empleado.";
            }
            return result;
        }

        public async Task<EmpleadoEditarGetResult> ActualizarEmpleado(EmpleadosEditar empleadoActualizar)
        {
            var result = new EmpleadoEditarGetResult();
            try
            {
                using (var httpClient = ClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(empleadoActualizar), System.Text.Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"{BaseUrl}ActualizarEmpleado", content);
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<EmpleadoEditarGetResult>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error actualizando el empleado");
                result.Success = false;
                result.Message = "Error actualizando el empleado.";
            }
            return result;
        }
    }
}
