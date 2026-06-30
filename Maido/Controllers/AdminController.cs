using Maido.Data;
using Maido.Models;
using Maido.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Maido.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDBContext _context;

        public AdminController(AppDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.Usuario = HttpContext.Session.Get<Usuario>("usuarioLogeado");
            return View();
        }

        [Route("Admin/Usuarios/Lista")]
        public IActionResult UsuarioList()
        {
            List<Usuario> list = _context.Usuarios.ToList();
            ViewBag.Usuario = HttpContext.Session.Get<Usuario>("usuarioLogeado");
            return View("Usuario/Index", list);
        }
        [Route("Admin/Usuarios/Nuevo")]
        public IActionResult UsuarioCreate()
        {
            ViewBag.Usuario = HttpContext.Session.Get<Usuario>("usuarioLogeado");
            return View("Usuario/Create", new Usuario());
        }
        [HttpPost]
        public IActionResult UsuarioCreate(Usuario newUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(newUsuario);
                _context.SaveChanges();
                return RedirectToAction("UsuarioList");
            }

            ViewBag.Usuario = HttpContext.Session.Get<Usuario>("usuarioLogeado");
            return View("Usuario/Create", newUsuario);
        }

    }
}
