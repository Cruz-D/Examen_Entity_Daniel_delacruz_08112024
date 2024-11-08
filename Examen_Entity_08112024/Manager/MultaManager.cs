using Examen_Entity_08112024.Context;
using Examen_Entity_08112024.Models;
using System.Collections.Generic;
using System.Linq;

namespace Examen_Entity_08112024.Manager
{
    public class MultaManager
    {
        private readonly dbContext _context;

        public MultaManager(dbContext context)
        {
            _context = context;
        }

        // Create
        public void AddMulta(Multa multa)
        {
            _context.Multas.Add(multa);
            _context.SaveChanges();
        }

        // Read
        public List<Multa> GetAllMultas()
        {
            return _context.Multas.ToList();
        }

        public Multa GetMultaById(int id)
        {
            return _context.Multas.Find(id);
        }

        // Update
        public void UpdateMulta(Multa multa)
        {
            _context.Entry(multa).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        // Delete
        public void DeleteMulta(int id)
        {
            var multa = _context.Multas.Find(id);
            if (multa != null)
            {
                _context.Multas.Remove(multa);
                _context.SaveChanges();
            }
        }
    }
}
