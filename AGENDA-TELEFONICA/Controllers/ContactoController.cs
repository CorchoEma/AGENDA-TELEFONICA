using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TODO_MVC_NETCORE.DTOs;
using TODO_MVC_NETCORE.Servicios.Interfaces;

namespace TODO_MVC_NETCORE.Controllers
{
    public class ContactoController : Controller
    {
        private readonly IContacto _contactoServices;
        private readonly UserManager<IdentityUser> _userManager;

        public ContactoController(IContacto contactoServices, UserManager<IdentityUser> userManager)
        {
            _contactoServices = contactoServices;
            _userManager = userManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            var idUserCurrent = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var response = _contactoServices.getContactos(idUserCurrent);
            return View(response);
        }

        public IActionResult FormularioCrearContacto()
        {
  
            return View();
        }

        [HttpPost]
        public IActionResult CreateContacto(CreateContactoDTO contacto)
        {
            var idUserCurrent = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var response = _contactoServices.crearContacto(contacto, idUserCurrent);
            return RedirectToAction("Index");
        }

        
        public IActionResult Borrar(int id)
        {
            var response = _contactoServices.borrarContacto(id);

            return RedirectToAction("Index");
        }

       
        public IActionResult FormularioEditarContacto(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = _contactoServices.getContacto(id);

            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }


        [HttpPost, ActionName("FormularioEditarContacto")]
        [ValidateAntiForgeryToken]
        public IActionResult EditPost(UpdateContactoDTO update)
        {
            var updateContacto = _contactoServices.updateContacto(update);

            if (updateContacto)
            {
                return RedirectToAction("Index");

            }
            else
            {
                return NotFound();
            }
            
        }
    }

}
