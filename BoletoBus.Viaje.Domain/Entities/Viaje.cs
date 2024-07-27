using BoletoBus.Common.Data.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BoletoBus.Viaje.Domain.Entities
{
    public class Viaje : AuditEntity<int>
    {
        #region "Atributos"

        [Key]
        [Column("IdViaje")]
        public override int Id { get; set; }

        [Column("IdBus")]
        public int IdBus { get; set; }

        [Column("IdRuta")]
        public int IdRuta { get; set; }

        [Column("FechaSalida")]
        public DateTime FechaSalida { get; set; }

        [Column("HoraSalida")]
        public TimeSpan HoraSalida { get; set; }

        [Column("FechaLlegada")]
        public DateTime FechaLlegada { get; set; }

        [Column("HoraLlegada")]
        public TimeSpan HoraLlegada { get; set; }

        [Column("Precio")]
        public decimal Precio { get; set; }

        [Column("TotalAsientos")]
        public int TotalAsientos { get; set; }

        [Column("AsientosReservados")]
        public int AsientosReservados { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column("AsientoDisponibles")]
        public int AsientoDisponibles { get; set; }

        [Column("FechaCreacion")]
        public override DateTime FechaCreacion { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion


    }
}
