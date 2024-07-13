

namespace BoletoBus.Common.Data.Base
{

    public abstract class AuditEntity<TType> : BaseEntity<TType>
    {

        public abstract DateTime FechaCreacion { get; set; }
    }
}
