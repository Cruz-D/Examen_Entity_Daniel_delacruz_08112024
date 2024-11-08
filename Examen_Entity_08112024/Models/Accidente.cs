using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_Entity_08112024.Models
{
    public class Accidente
    {
        public int AccidenteId { get; set; }
        public DateTime FechaHora { get; set; }
        public string Lugar { get; set; }
        public int NumeroRegistro { get; set; }

        // Relación N:N con Persona y Vehiculo (a través de tablas intermedias)
        public ICollection<PersonasAccidente> PersonasAccidentes { get; set; }
        public ICollection<VehiculoAccidente> VehiculoAccidentes { get; set; }
    }

}