﻿
using System.ComponentModel.DataAnnotations;


namespace BoletoBus.Viaje.Application.Dtos
{
    public abstract class ViajeBase
    {
        [Key]
        public int IdViaje { get; set; }
        public int IdBus { get; set; }
        public int IdRuta { get; set; }
        public DateTime FechaSalida { get; set; }
        public TimeSpan HoraSalida { get; set; }
        public DateTime FechaLlegada { get; set; }
        public TimeSpan HoraLlegada { get; set; }
        public decimal Precio { get; set; }
        public int TotalAsientos { get; set; }
        public int AsientosReservados { get; set; }
        public int AsientoDisponibles { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
