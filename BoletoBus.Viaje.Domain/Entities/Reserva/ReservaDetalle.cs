using BoletoBus.Common.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus.Viaje.Domain.Entities.Reserva
{
    public class ReservaDetalle: AuditEntity<int>
    {
        #region"Atributo"
        public override int Id { get; set; }
        public int IdReserva { get; set; }
        public int IdAsiento { get; set; }
        #endregion
    }
}
