

using System.ComponentModel.DataAnnotations;

namespace BoletoBus.Empleado.Application.Dtos
{
    public abstract class EmpleadoModel
    {
        [Key]
        public int IdEmpleado { get; set; }
        public string? Nombre { get; set; }
        public string? Cargo { get; set; }
    }
}
