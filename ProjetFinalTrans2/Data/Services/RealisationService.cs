using ProjetFinalTrans2.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjetFinalTrans2.Data.Services
{
    public class RealisationService : IRealisationService
    {
        private readonly AppDbContext _context;

        public RealisationService(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Realisation> GetAll()
        {
            return _context.Realisations.ToList();
        }

        public Realisation GetById(int id)
        {
            return _context.Realisations.FirstOrDefault(r => r.Id == id);
        }


        public void Add(Realisation realisation)
        {
            _context.Realisations.Add(realisation);
            _context.SaveChanges();
        }

        public void Update(Realisation realisation)
        {
            _context.Realisations.Update(realisation);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var realisation = _context.Realisations.Find(id);
            if (realisation != null)
            {
                _context.Realisations.Remove(realisation);
                _context.SaveChanges();
            }
        }

    }
}
