using BoletoBus.Common.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;


namespace BoletoBus.Entidades.Domain.Entities.Reserva
{
    public class Reserva : AuditEntity<int>
    {
      #region"Atributos"

        [Column("IdReserva")]
        public override int Id { get; set; }
        public int IdViaje { get; set; }
        public int IdPasajero { get; set; }
        public int AsientosReservados { get; set; }
        public decimal MontoTotal { get; set; }

#endregion
    }
}
