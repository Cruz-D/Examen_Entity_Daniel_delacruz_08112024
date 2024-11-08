using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_Entity_08112024.Models
{
    public class Vehiculo
    {
        public int VehiculoId { get; set; }
        public string Matricula { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }

        // Relación 1:1 con Multa
        public Multa Multa { get; set; }

        // Relación 1:N con Persona
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }

        // Relación N:N con Accidentes (a través de VehiculoAccidente)
        public ICollection<VehiculoAccidente> VehiculoAccidentes { get; set; }
    }

}