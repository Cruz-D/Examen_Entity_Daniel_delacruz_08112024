using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Examen_Entity_08112024.Models;
using System.Linq;
using System.Web;
using System.Reflection.Emit;

namespace Examen_Entity_08112024.Context
{
    public class dbContext : System.Data.Entity.DbContext
    {
        public dbContext() : base("name=SegurosDB")
        {
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Multa> Multas { get; set; }
        public DbSet<Accidente> Accidentes { get; set; }
        public DbSet<PersonasAccidente> PersonasAccidentes { get; set; }
        public DbSet<VehiculoAccidente> VehiculoAccidentes { get; set; }
     

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Relación 1:N entre Persona y Vehiculo
            modelBuilder.Entity<Vehiculo>()
                .HasRequired(v => v.Persona)
                .WithMany(p => p.Vehiculos)
                .HasForeignKey(v => v.PersonaId);

            // Relación 1:1 entre Persona y Multa
            modelBuilder.Entity<Persona>()
                .HasRequired(p => p.Multa)
                .WithRequiredPrincipal(m => m.Persona);

            // Relación 1:1 entre Vehiculo y Multa
            modelBuilder.Entity<Vehiculo>()
                .HasOptional(v => v.Multa)
                .WithRequired(m => m.Vehiculo);

            // Configuración de tabla intermedia PersonasAccidente para relación N:N entre Persona y Accidente
            modelBuilder.Entity<PersonasAccidente>()
                .HasKey(pa => pa.PersonasAccidenteId);

            modelBuilder.Entity<PersonasAccidente>()
                .HasRequired(pa => pa.Persona)
                .WithMany(p => p.PersonasAccidentes)
                .HasForeignKey(pa => pa.PersonaId);

            modelBuilder.Entity<PersonasAccidente>()
                .HasRequired(pa => pa.Accidente)
                .WithMany(a => a.PersonasAccidentes)
                .HasForeignKey(pa => pa.AccidenteId);

            // Configuración de tabla intermedia VehiculoAccidente para relación N:N entre Vehiculo y Accidente
            modelBuilder.Entity<VehiculoAccidente>()
                .HasKey(va => va.VehiculoAccidenteId);

            modelBuilder.Entity<VehiculoAccidente>()
                .HasRequired(va => va.Vehiculo)
                .WithMany(v => v.VehiculoAccidentes)
                .HasForeignKey(va => va.VehiculoId);

            modelBuilder.Entity<VehiculoAccidente>()
                .HasRequired(va => va.Accidente)
                .WithMany(a => a.VehiculoAccidentes)
                .HasForeignKey(va => va.AccidenteId);

     
        }
    }

}