
using System.ComponentModel.DataAnnotations;

namespace BoletoBus.Empleado.Domain.Entities
{
    public class Empleados
    {
        #region "Atributos"

        [Key]
        public int IdEmpleado { get; set; }

        public string? Nombre { get; set; }

        public string? Cargo { get; set; }

        #endregion
    }
}
