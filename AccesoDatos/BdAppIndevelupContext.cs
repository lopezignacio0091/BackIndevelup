using AccesoDatos.Modelo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccesoDatos
{
   public  class BdAppIndevelupContext : DbContext
    {

        public BdAppIndevelupContext(DbContextOptions<BdAppIndevelupContext> options) : base(options)
        {

        }


        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) { modelBuilder.Entity<Tarea>().HasOne(e => e.Usuario).WithMany(e => e.Tareas).OnDelete(DeleteBehavior.SetNull);}
    }
}
