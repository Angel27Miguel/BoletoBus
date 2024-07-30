
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BoletoBus.Common.Data.Base;

namespace BoletoBus.Reserva.Domain.Entities
{
    public class Reservas : AuditEntity<int>
    {
        #region "Atributos"

        [Key]
        [Column("IdReserva")]
        public override int Id { get; set; }

        [Column("IdViaje")]
        public int IdViaje { get; set; }

        [Column("IdPasajero")]
        public int IdPasajero { get; set; }

        [Column("AsientosReservados")]
        public int AsientosReservados { get; set; }

        [Column("MontoTotal")]
        public decimal MontoTotal { get; set; }

        [Column("FechaCreacion")]
        public override DateTime FechaCreacion { get; set; }
        #endregion
    }
}
