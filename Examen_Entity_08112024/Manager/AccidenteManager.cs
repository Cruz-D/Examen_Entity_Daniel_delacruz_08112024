using Examen_Entity_08112024.Context;
using Examen_Entity_08112024.Models;
using System.Collections.Generic;
using System.Linq;

namespace Examen_Entity_08112024.Manager
{
    public class AccidenteManager
    {
        private readonly dbContext _context;

        public AccidenteManager(dbContext context)
        {
            _context = context;
        }

        // Create
        public void AddAccidente(Accidente accidente)
        {
            _context.Accidentes.Add(accidente);
            _context.SaveChanges();
        }

        // Read
        public List<Accidente> GetAllAccidentes()
        {
            return _context.Accidentes.ToList();
        }

        public Accidente GetAccidenteById(int id)
        {
            return _context.Accidentes.Find(id);
        }

        // Update
        public void UpdateAccidente(Accidente accidente)
        {
            _context.Entry(accidente).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        // Delete
        public void DeleteAccidente(int id)
        {
            var accidente = _context.Accidentes.Find(id);
            if (accidente != null)
            {
                _context.Accidentes.Remove(accidente);
                _context.SaveChanges();
            }
        }
    }
}
