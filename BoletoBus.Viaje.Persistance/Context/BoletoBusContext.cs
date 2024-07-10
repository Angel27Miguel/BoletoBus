﻿using BoletoBus.Entidades.Domain.Entities.Empleado;
using Microsoft.EntityFrameworkCore;


namespace BoletoBus.Viaje.Persistance.Context
{
    public class BoletoBusContext : DbContext
    {

        public BoletoBusContext(DbContextOptions<BoletoBusContext> options) : base(options)
        {

        }

        #region"DB Sets de Angel Miguel"
        public DbSet<Domain.Entities.Viaje> Viaje { get; set; }
        


        #endregion



    }
}
