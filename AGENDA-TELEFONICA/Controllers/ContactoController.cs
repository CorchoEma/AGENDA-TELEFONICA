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
        public async Task <IActionResult> Index()
        {
            var idUserCurrent = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var response = await _contactoServices.getContactos(idUserCurrent);
            return View(response);
        }

        public IActionResult FormularioCrearContacto()
        {
  
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> CreateContacto(CreateContactoDTO contacto)
        {
            var idUserCurrent = HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var response = await _contactoServices.crearContacto(contacto, idUserCurrent);
            return RedirectToAction("Index");
        }

        
        public async Task <IActionResult> Borrar(int id)
        {
            var response = await _contactoServices.borrarContacto(id);

            return RedirectToAction("Index");
        }

       
        public async Task <IActionResult> FormularioEditarContacto(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _contactoServices.getContacto(id);

            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }


        [HttpPost, ActionName("FormularioEditarContacto")]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> EditPost(UpdateContactoDTO update)
        {
            var updateContacto = await _contactoServices.updateContacto(update);

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
