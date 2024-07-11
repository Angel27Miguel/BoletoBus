using Microsoft.EntityFrameworkCore;

namespace BoletoBus.Empleado.Persistance.Context
{
    public class BoletoBusContext : DbContext

    {
        public BoletoBusContext(DbContextOptions<BoletoBusContext> options) : base(options)
        {
            
        }

        public DbSet<Reserva.Domain.Entities.Reservas> Reserva { get; set; }
    }
}
