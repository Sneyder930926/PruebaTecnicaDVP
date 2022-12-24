using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class dbPruebaTecnicaContext :DbContext
    {
        public dbPruebaTecnicaContext(DbContextOptions<dbPruebaTecnicaContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Personas>(persona =>
            {
                persona.Property(x => x.Identificador).ValueGeneratedOnAdd();
                persona.Property(x => x.NumeroIdentificacion).HasColumnName("Numero_Identificacion");
                persona.Property(x => x.TipoIdentificacion).HasColumnName("Tipo_Identificacion");
                persona.Property(x => x.FechaCreacion).HasColumnName("Fecha_Creacion");
                persona.Property(x => x.TipoNumeroIdentificacion).HasColumnName("Tipo_Numero_Identificacion").ValueGeneratedOnAdd();
                persona.Property(x => x.NombresApellidos).HasColumnName("Nombre_Apellidos").ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Usuarios>(usuario =>
            {
                usuario.Property(x => x.Identificador).ValueGeneratedOnAdd();
                usuario.Property(x => x.FechaCreacion).HasColumnName("Fecha_Creacion");
            });
        }

        public DbSet<Personas> Personas { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
