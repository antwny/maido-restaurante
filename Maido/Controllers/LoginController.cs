using Maido.Data;
using Maido.Data.Interfaces;
using Maido.Data.Repository;
using Maido.Models;
using Maido.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Maido.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepo;

        public LoginController(IUsuarioRepository usuarioRepo)
        {
            
            _usuarioRepo = usuarioRepo;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            Usuario u = _usuarioRepo.GetByUsernameAndPassword(username, password);
            if (u == null)
            { 
                ViewBag.Error = "Usuario o contraseña incorrectos";
                return View();
            }
            HttpContext.Session.Set("usuarioLogeado", u);
            return RedirectToAction("Index", u.Rol);

        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}