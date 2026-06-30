using Maido.Models;

namespace Maido.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario GetByUsernameAndPassword(string username, string password);
        IEnumerable<Usuario> GetAll();
        Usuario GetById(int id);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void DeleteById(int id);
    }
}
