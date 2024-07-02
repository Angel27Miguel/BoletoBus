using BoletoBus.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoletoBus.Entidades.Domain.Entities.Empleado
{
    public class Empleado : AuditEntity<int>
    {
        [Column("IdEmpleado")]
        public override int Id { get; set; }
    }
}
