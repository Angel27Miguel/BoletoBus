

namespace BoletoBus.Viaje.Persistance.Model.Reserva
{
    public class ReservaDetalleModel
    {
        #region"Atributo"
        public int IdReservaDetalle { get; set; }
        public int IdReserva { get; set; }
        public int IdAsiento { get; set; }

        #endregion
    }
}
