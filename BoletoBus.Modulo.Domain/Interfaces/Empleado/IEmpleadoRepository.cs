using BoletoBus.Common.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus.Modulo.Domain.Interfaces.Empleado
{
    internal interface IEmpleadoRepository : IBaseRepository<Domain.Entities.Empleado.Empleados,int>
    {
        List<Entities.Empleado.Empleados> GetEmpleadosById (int IdEmpleado);
    }
}
