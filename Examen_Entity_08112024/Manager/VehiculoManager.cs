using Examen_Entity_08112024.Context;
using Examen_Entity_08112024.Models;
using System.Collections.Generic;
using System.Linq;

namespace Examen_Entity_08112024.Manager
{
    public class VehiculoManager
    {
        private readonly dbContext _context;

        public VehiculoManager(dbContext context)
        {
            _context = context;
        }

        // Create
        public void AddVehiculo(Vehiculo vehiculo)
        {
            _context.Vehiculos.Add(vehiculo);
            _context.SaveChanges();
        }

        // Read
        public List<Vehiculo> GetAllVehiculos()
        {
            return _context.Vehiculos.ToList();
        }

        public Vehiculo GetVehiculoById(int id)
        {
            return _context.Vehiculos.Find(id);
        }

        // Update
        public void UpdateVehiculo(Vehiculo vehiculo)
        {
            _context.Entry(vehiculo).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        // Delete
        public void DeleteVehiculo(int id)
        {
            var vehiculo = _context.Vehiculos.Find(id);
            if (vehiculo != null)
            {
                _context.Vehiculos.Remove(vehiculo);
                _context.SaveChanges();
            }
        }
    }
}
