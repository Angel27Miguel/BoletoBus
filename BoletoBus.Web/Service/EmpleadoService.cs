using BoletoBus.Empleado.Application.Dtos;
using BoletoBus.Web.Models.EmpleadosModels;
using Newtonsoft.Json;

namespace BoletoBus.Web.Service
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly HttpClient _httpClient;

        public EmpleadoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EmpleadoGetListResult> GetEmpleados()
        {
            var response = await _httpClient.GetAsync("http://localhost:5297/api/Empleado/GetEmpleado");
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<EmpleadoGetListResult>(apiResponse);
        }

        public async Task<EmpleadoGetResult> GetEmpleadoById(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5297/api/Empleado/GetEmpleadoById?id={id}");
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<EmpleadoGetResult>(apiResponse);
        }

        public async Task<EmpleadoGuardarResult> GuardarEmpleado(EmpleadosGuardar empleadoGuardar)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5297/api/Empleado/GuardarEmpleado", empleadoGuardar);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<EmpleadoGuardarResult>(apiResponse);
        }

        public async Task<EmpleadoEditarGetResult> ActualizarEmpleado(EmpleadosEditar empleadoActualizar)
        {
            var response = await _httpClient.PutAsJsonAsync("http://localhost:5297/api/Empleado/ActualizarEmpleado", empleadoActualizar);
            var apiResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<EmpleadoEditarGetResult>(apiResponse);
        }
    }
}