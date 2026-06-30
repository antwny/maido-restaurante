using Maido.Models;

namespace Maido.Data.Interfaces
{
    public interface IMesaRepository
    {
        IEnumerable<Mesa> GetAll();
        Mesa GetById(int id);
        void Add(Mesa mesa);
        void Update(Mesa mesa);
        void DeleteById(int id);
    }
}
