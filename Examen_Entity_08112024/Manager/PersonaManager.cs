using Examen_Entity_08112024.Context;
using Examen_Entity_08112024.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Examen_Entity_08112024.Manager
{
    public class PersonaManager
    {
        private readonly dbContext _context;
        private PersonaManager _personaManager;

        public PersonaManager(dbContext context)
        {
            _context = context;
        }

        // Create
        public void AddPersona(Persona persona)
        {
            _context.Personas.Add(persona);
            _context.SaveChanges();
        }

        // Read
        public List<Persona> GetAllPersonas()
        {
            return _context.Personas.ToList();
        }

        public Persona GetPersonaById(int id)
        {
            return _context.Personas.FirstOrDefault(p => p.PersonaId == id);
        }

        // Update
        public void UpdatePersona(Persona persona)
        {
            var existingPersona = _context.Personas.FirstOrDefault(p => p.PersonaId == persona.PersonaId);
            if (existingPersona != null)
            {
                existingPersona.Nombre = persona.Nombre;
                existingPersona.Apellido = persona.Apellido;
                existingPersona.Direccion = persona.Direccion;
                existingPersona.Poblacion = persona.Poblacion;
                existingPersona.Telefono = persona.Telefono;
                existingPersona.DNI = persona.DNI;
                existingPersona.Rol = persona.Rol;

                _context.SaveChanges();
            }
        }

        // Delete
        public void DeletePersona(int id)
        {
            var persona = _context.Personas.FirstOrDefault(p => p.PersonaId == id);
            if (persona != null)
            {
                _context.Personas.Remove(persona);
                _context.SaveChanges();
            }
        }
    }
}
