

using System.ComponentModel.DataAnnotations;

namespace BoletoBus.Viaje.Persistance.Model.Reserva
{
    public class ReservaModel 
    {
        #region "Atributos"
        [Key]
        public int IdReserva { get; set; }
        public int IdViaje { get; set; }
        public int IdPasajero { get; set; }
        public int AsientosReservados { get; set; }
        public decimal MontoTotal { get; set; }

        #endregion
    }
}
