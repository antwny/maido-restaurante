using Maido.Data.Interfaces;
using Maido.Models;

namespace Maido.Data.Repository
{
    public class MesaRepository : IMesaRepository
    {
        private readonly AppDBContext _context;
        public MesaRepository(AppDBContext context)
        {
            _context = context;
        }
        public void Add(Mesa mesa)
        {
            _context.Mesas.Add(mesa);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var mesa = _context.Mesas.Find(id);
            if (mesa != null)
            {
                _context.Mesas.Remove(mesa);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Mesa> GetAll()
        {
            return _context.Mesas.ToList();
        }

        public Mesa GetById(int id)
        {
            return _context.Mesas.Find(id);
        }

        public void Update(Mesa mesa)
        {
            _context.Mesas.Update(mesa);
            _context.SaveChanges();
        }
    }
}
