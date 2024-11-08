using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_Entity_08112024.Models
{
    public class PersonasAccidente
    {
        public int PersonasAccidenteId { get; set; }

        // Relación N:1 con Persona
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }

        // Relación N:1 con Accidente
        public int AccidenteId { get; set; }
        public Accidente Accidente { get; set; }
    }

}