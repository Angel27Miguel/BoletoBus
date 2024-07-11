
using System.ComponentModel.DataAnnotations;

namespace BoletoBus.Reserva.Application.Dtos
{
    public abstract class ReservaBase
    {
        [Key]
        public int IdReserva { get; set; }
        public int IdViaje { get; set; }
        public int IdPasajero { get; set; }
        public int AsientosReservados { get; set; }
        public decimal MontoTotal { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
