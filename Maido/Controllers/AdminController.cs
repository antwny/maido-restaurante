using Maido.Data;
using Maido.Data.Interfaces;
using Maido.Models;
using Maido.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Maido.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUsuarioRepository _usuarioRepo;

        public AdminController(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }
        public IActionResult Index()
        {
            ViewBag.Usuario = HttpContext.Session.Get<Usuario>("usuarioLogeado");
            return View();
        }

        [Route("Admin/Usuarios/Lista")]
        public IActionResult UsuarioList()
        {
            IEnumerable<Usuario> list = _usuarioRepo.GetAll();
            ViewBag.Usuario = HttpContext.Session.Get<Usuario>("usuarioLogeado");
            return View("Usuario/Index", list);
        }
       
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

                _usuarioRepo.Add(newUsuario);
                return RedirectToAction(nameof(UsuarioList));
            }
        
            ModelState.AddModelError("", "No se pudo crear el usuario. Por favor, revise los datos ingresados.");
            ViewBag.Usuario = HttpContext.Session.Get<Usuario>("usuarioLogeado");
            return View("Usuario/Create", newUsuario);
        }

    }
}
