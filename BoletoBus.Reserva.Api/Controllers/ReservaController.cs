using BoletoBus.Reserva.Application.Dtos;
using BoletoBus.Reserva.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BoletoBus.Reserva.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaServices reservaServices;

        public ReservaController(IReservaServices reservaServices)
        {
            this.reservaServices = reservaServices;
        }

        [HttpGet("GetReserva")]
        public IActionResult Get()
        {
            var result = this.reservaServices.GetReserva();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPost("GetReservaById")]
        public IActionResult Get(int id)
        {
            var result = this.reservaServices.GetReservaById(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPost("GuardarReserva")]
        public IActionResult Post([FromBody] ReservaGuardar reservaGuardar)
        {
            var result = this.reservaServices.GuardarReserva(reservaGuardar);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }

        }
        [HttpPost("ActualizarReserva")]
        public IActionResult Put(ReservaEditar reservaEditar)
        {
            var result = this.reservaServices.EditarReserva(reservaEditar);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPost("EliminarReserva")]
        public IActionResult Delete(ReservaEliminar reservaEliminar)
        {
            var result = this.reservaServices.EliminarReserva(reservaEliminar);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
