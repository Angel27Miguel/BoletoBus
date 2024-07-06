using BoletoBus.Common.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus.Viaje.Domain.Interfaces.IEmpleado
{
    public interface IEmpleado : IBaseRepository<Entities.Reserva.ReservaDetalle, int>
    {
    }
}
