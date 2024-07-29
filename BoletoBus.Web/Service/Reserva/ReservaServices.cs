using BoletoBus.Common;
using BoletoBus.Reserva.Application.Dtos;
using BoletoBus.Web.Models.Reserva;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus.Web.Service.Reserva
{
    public class ReservaService : IReservaService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ReservaService> _logger;
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _baseUrl;

        public ReservaService(IConfiguration configuration, ILogger<ReservaService> logger, IHttpClientFactory clientFactory)
        {
            _configuration = configuration;
            _logger = logger;
            _clientFactory = clientFactory;
            _baseUrl = _configuration["apiConfig:baseUrlReserva"];
        }

        public async Task<ReservaGetListResult> GetReservas()
        {
            var result = new ReservaGetListResult();
            try
            {
                using (var httpClient = _clientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"{_baseUrl}GetReserva");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ReservaGetListResult>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error obteniendo la lista de reservas");
                result.Success = false;
                result.Message = "Error obteniendo la lista de reservas.";
            }
            return result;
        }

        public async Task<ReservaGetDetailsResult> GetReservaById(int id)
        {
            var result = new ReservaGetDetailsResult();
            try
            {
                using (var httpClient = _clientFactory.CreateClient())
                {
                    var response = await httpClient.GetAsync($"{_baseUrl}/Reserva/GetReservaById?id={id}");
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ReservaGetDetailsResult>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error obteniendo la reserva con ID {id}");
                result.Success = false;
                result.Message = $"Error obteniendo la reserva con ID {id}.";
            }
            return result;
        }

        public async Task<ReservaGuardarResult> GuardarReserva(ReservaGuardar reservaGuardar)
        {
            var result = new ReservaGuardarResult();
            try
            {
                using (var httpClient = _clientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(reservaGuardar), Encoding.UTF8, "application/json");
                    var response = await httpClient.PostAsync($"{_baseUrl}/Reserva/GuardarReserva", content);
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ReservaGuardarResult>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error guardando la reserva");
                result.Success = false;
                result.Message = "Error guardando la reserva.";
            }
            return result;
        }

        public async Task<ReservaEditarGetResult> ActualizarReserva(ReservaEditar reservaActualizar)
        {
            var result = new ReservaEditarGetResult();
            try
            {
                using (var httpClient = _clientFactory.CreateClient())
                {
                    var content = new StringContent(JsonConvert.SerializeObject(reservaActualizar), Encoding.UTF8, "application/json");
                    var response = await httpClient.PutAsync($"{_baseUrl}/Reserva/ActualizarReserva", content);
                    response.EnsureSuccessStatusCode();
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    result = JsonConvert.DeserializeObject<ReservaEditarGetResult>(apiResponse);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error actualizando la reserva");
                result.Success = false;
                result.Message = "Error actualizando la reserva.";
            }
            return result;
        }
    }
}
