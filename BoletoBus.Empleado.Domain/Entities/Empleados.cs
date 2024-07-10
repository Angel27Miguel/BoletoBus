
using BoletoBus.Common.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoletoBus.Empleado.Domain.Entities
{
    public class Empleados : BaseEntity<int>
    {
        #region "Atributos"

        [Column("IdEmpleado")]
        public override int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Cargo { get; set; }

        #endregion
    }
}
