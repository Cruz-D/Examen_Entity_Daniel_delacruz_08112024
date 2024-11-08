using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_Entity_08112024.Models
{
    public class Multa
    {
        public int MultaId { get; set; }
        public DateTime FechaHora { get; set; }
        public string Lugar { get; set; }
        public decimal Importe { get; set; }
        public int NumeroRegistro { get; set; }

        // Relación 1:1 con Persona
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }

        // Relación 1:1 con Vehiculo
        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }
    }

}