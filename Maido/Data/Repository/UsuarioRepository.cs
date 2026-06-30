using Maido.Data.Interfaces;
using Maido.Models;

namespace Maido.Data.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDBContext _context;
        public UsuarioRepository(AppDBContext contexto)
        {
              _context = contexto;
        }
        public void Add(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void DeleteById(int id)
        {
            Usuario usuarioAeliminar = GetById(id);
            _context.Usuarios.Remove(usuarioAeliminar);
            _context.SaveChanges();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario GetById(int id)
        {

           return _context.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public Usuario GetByUsernameAndPassword(string username, string password)
        {
            return _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == username && u.Contrasena == password);
        }

        public void Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }
    }
}
