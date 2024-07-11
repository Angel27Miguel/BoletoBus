using BoletoBus.Empleado.Application.Dtos;
using BoletoBus.Empleado.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BoletoBus.Empleado.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoServices empleadoServices;
        public EmpleadoController(IEmpleadoServices empleadoServices)
        {
            this.empleadoServices = empleadoServices;
            
        }
        [HttpGet("GetEmpleado")]
        public IActionResult Get()
        {
            var result = this.empleadoServices.GetEmpleados();
            if (!result.Success) 
            {
             return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPost("GetEmpleadoById")]
        public IActionResult Get(int id)
        {
            var result = this.empleadoServices.GetEmpleado(id);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPost("GuardarEmpleado")]
        public IActionResult Post([FromBody] EmpleadosGuardar empleadosGuardar)
        {
            var result = this.empleadoServices.GuardarEmpleado(empleadosGuardar);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }

        }
        [HttpPost("ActualizarEmpleado")]
        public IActionResult Put(EmpleadosEditar empleadosEditar)
        {
            var result = this.empleadoServices.EditarEmpleado(empleadosEditar);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            else
            {
                return Ok(result);
            }
        }
        [HttpPost("EliminarEmpleado")]
        public IActionResult Delete(EmpleadosEliminar empleadosEliminar)
        {
            var result = this.empleadoServices.EliminarEmpleado(empleadosEliminar);
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
