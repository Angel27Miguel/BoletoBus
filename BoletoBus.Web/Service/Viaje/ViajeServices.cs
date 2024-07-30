using BoletoBus.Common;
using BoletoBus.Viaje.Application.Dtos;
using BoletoBus.Web.Models.ViajesModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus.Web.Service.Viaje
{
    public class ViajeService : IViajeServices
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger<ViajeService> Logger;
        private readonly IHttpClientFactory ClientFactory;
        private readonly string BaseUrl;

        public ViajeService(IConfiguration configuration, ILogger<ViajeService> logger, IHttpClientFactory clientFactory)
        {
            Configuration = configuration;
            Logger = logger;
            ClientFactory = clientFactory;
            BaseUrl = Configuration["apiConfig:baseUrlViaje"]; 
        }

        public async Task<ViajeGetListResult> GetViajes()
        {
            var result = new ViajeGetListResult();
            try
            {
                using (var httpClient = ClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"{BaseUrl}/GetViaje");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ViajeGetListResult>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error obteniendo la lista de viajes");
                result.Success = false;
                result.Message = "Error obteniendo la lista de viajes.";
            }
            return result;
        }

        public async Task<ViajeGetDetailsResult> GetViajeaById(int id)
        {
            var result = new ViajeGetDetailsResult();
            try
            {
                using (var httpClient = ClientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"{BaseUrl}/GetViajeById?id={id}");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ViajeGetDetailsResult>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, $"Error obteniendo el viaje con ID {id}");
                result.Success = false;
                result.Message = $"Error obteniendo el viaje con ID {id}.";
            }
            return result;
        }

        public async Task<ViajeGuardarResult> GuardarViaje(ViajeGuardar viajeGuardar)
        {
            var result = new ViajeGuardarResult();
            try
            {
                using (var httpClient = ClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(viajeGuardar), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync($"{BaseUrl}/GuardarViaje", content);
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ViajeGuardarResult>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error guardando el viaje");
                result.Success = false;
                result.Message = "Error guardando el viaje.";
            }
            return result;
        }

        public async Task<ViajeEditarGetResult> ActualizarViaje(ViajeEditar viajeEditar)
        {
            var result = new ViajeEditarGetResult();
            try
            {
                using (var httpClient = ClientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(viajeEditar), Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"{BaseUrl}/ActualizarViaje", content);
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ViajeEditarGetResult>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "Error actualizando el viaje");
                result.Success = false;
                result.Message = "Error actualizando el viaje.";
            }
            return result;
        }

        
        
    }
}
