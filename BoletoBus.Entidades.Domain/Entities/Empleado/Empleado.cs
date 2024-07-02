using BoletoBus.Common.Data.Base;

namespace BoletoBus.Entidades.Domain.Entities.Empleado
{
    public class Empleado : AuditEntity<int>
    {
        public override int Id { get; set; }
    }
}
