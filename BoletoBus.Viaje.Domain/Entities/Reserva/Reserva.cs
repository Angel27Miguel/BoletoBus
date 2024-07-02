using BoletoBus.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;


namespace BoletoBus.Entidades.Domain.Entities.Reserva
{
    public class Reserva : AuditEntity<int>
    {
        [Column("IdReserva")]
        public override int Id { get; set; }
    }
}
