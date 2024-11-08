using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_Entity_08112024.Models
{
    public class VehiculoAccidente
    {
        public int VehiculoAccidenteId { get; set; }

        // Relación N:1 con Vehiculo
        public int VehiculoId { get; set; }
        public Vehiculo Vehiculo { get; set; }

        // Relación N:1 con Accidente
        public int AccidenteId { get; set; }
        public Accidente Accidente { get; set; }
    }

}