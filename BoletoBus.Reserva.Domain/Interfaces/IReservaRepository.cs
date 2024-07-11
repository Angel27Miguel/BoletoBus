
using BoletoBus.Common.Data.Repository;

namespace BoletoBus.Reserva.Domain.Interfaces
{
    public interface  IReservaRepository : IBaseRepository<Entities.Reservas, int>
    {
        List<Entities.Reservas> GetReservasByID(int IdReserva);
    }
}
