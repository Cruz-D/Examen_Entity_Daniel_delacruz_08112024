namespace Examen_Entity_08112024.Migrations
{
    using Examen_Entity_08112024.Context;
    using Examen_Entity_08112024.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Examen_Entity_08112024.Context.dbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Examen_Entity_08112024.Context.dbContext context)
        {
            // Asegúrate de que la base de datos esté creada
            context.Database.CreateIfNotExists();

            // Verifica si ya existen datos en la tabla Personas para evitar duplicados
            if (!context.Personas.Any())
            {
                var personas = new[]
                {
                    new Persona { Nombre = "Juan", Apellido = "Pérez", Direccion = "Calle 123", Poblacion = "Madrid", Telefono = "123456789", DNI = "12345678A", Rol = "Admin" },
                    new Persona { Nombre = "María", Apellido = "García", Direccion = "Avenida 456", Poblacion = "Barcelona", Telefono = "987654321", DNI = "87654321B", Rol = "User" }
                };

                context.Personas.AddRange(personas);
                context.SaveChanges();
            }

            // Verifica si ya existen datos en la tabla Vehiculos para evitar duplicados
            if (!context.Vehiculos.Any())
            {
                var vehiculos = new[]
                {
                    new Vehiculo { Matricula = "ABC123", Marca = "Toyota", Modelo = "Corolla", PersonaId = context.Personas.First(p => p.DNI == "12345678A").PersonaId },
                    new Vehiculo { Matricula = "XYZ789", Marca = "Honda", Modelo = "Civic", PersonaId = context.Personas.First(p => p.DNI == "87654321B").PersonaId }
                };

                context.Vehiculos.AddRange(vehiculos);
                context.SaveChanges();
            }

            // Verifica si ya existen datos en la tabla Multas para evitar duplicados
            if (!context.Multas.Any())
            {
                var multas = new[]
                {
                    new Multa { FechaHora = DateTime.Now.AddMonths(-1), Lugar = "Calle Falsa 123", NumeroRegistro = 1, PersonaId = context.Personas.First(p => p.DNI == "12345678A").PersonaId, VehiculoId = context.Vehiculos.First(v => v.Matricula == "ABC123").VehiculoId },
                    new Multa { FechaHora = DateTime.Now.AddMonths(-2), Lugar = "Plaza Mayor", NumeroRegistro = 2, PersonaId = context.Personas.First(p => p.DNI == "87654321B").PersonaId, VehiculoId = context.Vehiculos.First(v => v.Matricula == "XYZ789").VehiculoId }
                };

                context.Multas.AddRange(multas);
                context.SaveChanges();
            }

            // Verifica si ya existen datos en la tabla Accidentes para evitar duplicados
            if (!context.Accidentes.Any())
            {
                var accidentes = new[]
                {
                    new Accidente { FechaHora = DateTime.Now.AddMonths(-1), Lugar = "Calle Falsa 123", NumeroRegistro = 1 },
                    new Accidente { FechaHora = DateTime.Now.AddMonths(-2), Lugar = "Plaza Mayor", NumeroRegistro = 2 }
                };

                context.Accidentes.AddRange(accidentes);
                context.SaveChanges();
            }

            // Verifica si ya existen datos en la tabla PersonasAccidente para evitar duplicados
            if (!context.PersonasAccidentes.Any())
            {
                var personasAccidentes = new[]
                {
                    new PersonasAccidente { PersonaId = context.Personas.First(p => p.DNI == "12345678A").PersonaId, AccidenteId = context.Accidentes.First(a => a.NumeroRegistro == 1).AccidenteId },
                    new PersonasAccidente { PersonaId = context.Personas.First(p => p.DNI == "87654321B").PersonaId, AccidenteId = context.Accidentes.First(a => a.NumeroRegistro == 2).AccidenteId }
                };

                context.PersonasAccidentes.AddRange(personasAccidentes);
                context.SaveChanges();
            }

            // Verifica si ya existen datos en la tabla VehiculoAccidentes para evitar duplicados
            if (!context.VehiculoAccidentes.Any())
            {
                var vehiculoAccidentes = new[]
                {
                    new VehiculoAccidente { VehiculoId = context.Vehiculos.First(v => v.Matricula == "ABC123").VehiculoId, AccidenteId = context.Accidentes.First(a => a.NumeroRegistro == 1).AccidenteId },
                    new VehiculoAccidente { VehiculoId = context.Vehiculos.First(v => v.Matricula == "XYZ789").VehiculoId, AccidenteId = context.Accidentes.First(a => a.NumeroRegistro == 2).AccidenteId }
                };

                context.VehiculoAccidentes.AddRange(vehiculoAccidentes);
                context.SaveChanges();
            }
        }
    }

}
  