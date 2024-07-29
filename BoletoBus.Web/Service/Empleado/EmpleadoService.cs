using BoletoBus.Empleado.Application.Dtos;
using BoletoBus.Web.Models.EmpleadosModels;
using Newtonsoft.Json;

namespace BoletoBus.Web.Service.Empleado
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<EmpleadoService> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _baseUrl;

        public EmpleadoService(IConfiguration configuration, ILogger<EmpleadoService> logger, IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _logger = logger;
            _clientFactory = clientFactory;
            _baseUrl = _configuration["apiConfig:baseUrlEmpleado"];
        }

        public async Task<EmpleadoGetListResult> GetEmpleados()
        {
            var result = new EmpleadoGetListResult();
            try
            {
                using (var httpClient = _clientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"{_baseUrl}GetEmpleado");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<EmpleadoGetListResult>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo la lista de empleados");
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
                using (var httpClient = _clientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"{_baseUrl}/Empleado/GetEmpleadoById?id={id}");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<EmpleadoGetDetailsResult>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo el empleado con ID {id}");
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
                using (var httpClient = _clientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(empleadoGuardar), System.Text.Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync($"{_baseUrl}/Empleado/GuardarEmpleado", content);
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<EmpleadoGuardarResult>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error guardando el empleado");
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
                using (var httpClient = _clientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(empleadoActualizar), System.Text.Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"{_baseUrl}/Empleado/ActualizarEmpleado", content);
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<EmpleadoEditarGetResult>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error actualizando el empleado");
                result.Success = false;
                result.Message = "Error actualizando el empleado.";
            }
            return result;
        }
    }
}
