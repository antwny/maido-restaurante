using Maido.Data.Interfaces;
using Maido.Models;
using Maido.Utils;
using Microsoft.AspNetCore.Mvc;

namespace Maido.Controllers
{
    public class MeseroController : Controller
    {
        private readonly IMesaRepository _mesaRepo;
          
        public MeseroController(IMesaRepository mesaRepo)
        {
            _mesaRepo = mesaRepo;
            
        }
        public IActionResult Index()
        {
            ViewBag.Usuario = HttpContext.Session.Get<Usuario>("usuarioLogeado"); 
            return View(_mesaRepo.GetAll());
        }
    }
}
