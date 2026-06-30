using Maido.Data;
using Maido.Models;
using Maido.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Maido.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDBContext _context;

        public LoginController(AppDBContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            Usuario u = _context.Usuarios.FirstOrDefault(e => e.NombreUsuario == username && e.Contrasena == password);
            if (u == null)
            { 
                ViewBag.Error = "Usuario o contraseña incorrectos";
                return View();
            }
            HttpContext.Session.Set("usuarioLogeado", u);
            return RedirectToAction("Index", "Admin");

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}