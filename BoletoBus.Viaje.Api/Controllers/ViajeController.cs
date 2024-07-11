using BoletoBus.Viaje.Application.Dtos;
using BoletoBus.Viaje.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BoletoBus.Viaje.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeController : ControllerBase
    {
        private readonly IviajeServices viajeServices;
        public ViajeController(IviajeServices iviajeServices)
        {
            this.viajeServices = iviajeServices;
        }

        [HttpGet("GetViaje")]
        public IActionResult Get()
        {
            var result = this.viajeServices.GetViajes();
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPost("GetViajeById")]
        public IActionResult Get(int id)
        {
            var result = this.viajeServices.GetViaje(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPost("GuardarViaje")]
        public IActionResult Post([FromBody] ViajeGuardar viajeGuardar)
        {
            var result = this.viajeServices.GuardarViaje(viajeGuardar);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }

        }
        [HttpPost("ActualizarViaje")]
        public IActionResult Put(ViajeEditar viajeEditar)
        {
            var result = this.viajeServices.EditarViaje(viajeEditar);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPost("EliminarViaje")]
        public IActionResult Delete(ViajeEliminar viajeEliminar)
        {
            var result = this.viajeServices.EliminarViaje(viajeEliminar);
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

