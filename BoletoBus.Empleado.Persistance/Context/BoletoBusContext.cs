

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BoletoBus.Empleado.Persistance.Context
{
    public class BoletoBusContext : DbContext
    {
        public BoletoBusContext(DbContextOptions<BoletoBusContext> options) : base(options)
        {
            
        }

        public DbSet<Domain.Entities.Empleados> Empleado { get; set; }
    }
}
