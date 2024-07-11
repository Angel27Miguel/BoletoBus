
using BoletoBus.Common.Data.Repository;

namespace BoletoBus.Empleado.Domain.Interfaces
{
    public interface IEmpleadoRepository : IBaseRepository<Entities.Empleados, int>
    {
        List<Entities.Empleados> GetEmpleadosByID(int idEmpleado);

        
    }
}
