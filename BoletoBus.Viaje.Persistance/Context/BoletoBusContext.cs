
using Microsoft.EntityFrameworkCore;


namespace BoletoBus.Viaje.Persistance.Context
{
    public class BoletoBusContext : DbContext
    {

        public BoletoBusContext(DbContextOptions<BoletoBusContext> options) : base(options)
        {

        }

        public DbSet<Domain.Entities.Viaje> Viaje { get; set; }



    }
}
