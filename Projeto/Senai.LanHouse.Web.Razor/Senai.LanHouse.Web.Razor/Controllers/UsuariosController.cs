using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.LanHouse.Web.Razor.Contexts;
using Senai.LanHouse.Web.Razor.Models;

namespace Senai.LanHouse.Web.Razor.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly LanHouseContext _context;

        public UsuariosController(LanHouseContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Id,Email,Senha")] Usuarios usuario)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Usuarios.FirstOrDefault(i => i.Email == usuario.Email && i.Senha == usuario.Senha);
                if (user != null)
                {
                    HttpContext.Session.SetString("email", usuario.Email);
                    return RedirectToAction("Index", "RegistrosDefeitos");
                }
                ViewBag.Erro = "E-mail ou senha incorretos";
            }
            return View(usuario);
        }
    }
}
