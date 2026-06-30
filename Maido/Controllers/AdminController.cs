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
        private IEnumerable<String> roles = new List<string> { "Mesero", "Chef", "Cajero", "Admin" };

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
            ViewBag.Roles = roles;
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

        public IActionResult UsuarioEditar(int id)
        {
            Usuario usuarioAeditar = _usuarioRepo.GetById(id);
            
            ViewBag.Roles = roles;
            ViewBag.Usuario = HttpContext.Session.Get<Usuario>("usuarioLogeado");
            return View("Usuario/Edit",usuarioAeditar);
        }
        [HttpPost]
        public IActionResult UsuarioEditar(Usuario usuario)
        {
            _usuarioRepo.Update(usuario);
            return RedirectToAction("UsuarioList");
        }

        public IActionResult UsuarioDesactivar(int id)
        {
            Usuario usuarioAdesactivar=_usuarioRepo.GetById(id);
            usuarioAdesactivar.Activo = false;
            _usuarioRepo.Update(usuarioAdesactivar);
            return RedirectToAction("UsuarioList");
        }

        public IActionResult UsuarioActivar(int id)
        {
            Usuario usuarioAdesactivar = _usuarioRepo.GetById(id);
            usuarioAdesactivar.Activo = true;
            _usuarioRepo.Update(usuarioAdesactivar);
            return RedirectToAction("UsuarioList");
        }

    }
}
