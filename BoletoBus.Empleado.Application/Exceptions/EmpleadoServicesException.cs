using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoletoBus.Empleado.Application.Exceptions
{
    public class EmpleadoServicesException : Exception
    {
        public EmpleadoServicesException(string massage) : base(massage)
        {

        }

    
    }
}
