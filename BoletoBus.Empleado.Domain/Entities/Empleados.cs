
using BoletoBus.Common.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoletoBus.Empleado.Domain.Entities
{
    public class Empleados : BaseEntity<int>
    {
        #region "Atributos"

        [Key]
        [Column("IdEmpleado")]
        public override int Id { get; set; }
        [Column("Nombre")]
        public string? Nombre { get; set; }

        [Column("Cargo")]
        public string? Cargo { get; set; }
        #endregion
    }
}
