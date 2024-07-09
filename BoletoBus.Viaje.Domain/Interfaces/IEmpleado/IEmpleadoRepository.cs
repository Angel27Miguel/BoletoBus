using BoletoBus.Common.Data.Repository;


namespace BoletoBus.Viaje.Domain.Interfaces.IEmpleado
{
    public interface IEmpleado : IBaseRepository<Entities.Reserva.ReservaDetalle, int>
    {
    }
}
