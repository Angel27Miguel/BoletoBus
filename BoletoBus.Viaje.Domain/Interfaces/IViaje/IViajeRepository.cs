using BoletoBus.Common.Data.Repository;


namespace BoletoBus.Entidades.Domain.Interfaces.IViaje
{
    public interface IViajeRepository  : IBaseRepository<Entities.Viaje.Viaje, int>
    {
        List<Entities.Viaje.Viaje> GetViajesByID(int idViaje);


    }
    
}
