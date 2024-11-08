using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_Entity_08112024.Models
{
    public class Persona
    {
        public int PersonaId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Poblacion { get; set; }
        public string Telefono { get; set; }
        public string DNI { get; set; }
        public string Rol { get; set; }

        // Relación 1:N con Vehiculo
        public ICollection<Vehiculo> Vehiculos { get; set; }

        // Relación 1:1 con Multa
        public Multa Multa { get; set; }

        // Relación N:N con Accidentes (a través de PersonasAccidente)
        public ICollection<PersonasAccidente> PersonasAccidentes { get; set; }

        
    }

}