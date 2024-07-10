using BoletoBus.Common.Data.Repository;


namespace BoletoBus.Viaje.Domain.Interfaces
{
    public interface IViajeRepository : IBaseRepository<Entities.Viaje, int>
    {
        List<Entities.Viaje> GetViajesByID(int idViaje);


    }

}
