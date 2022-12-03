using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TODO_MVC_NETCORE.DTOs;
using TODO_MVC_NETCORE.Servicios.Interfaces;

namespace TODO_MVC_NETCORE.Controllers
{
    public class ContactoController : Controller
    {
        private readonly IContacto _contactoServices;

        public ContactoController(IContacto contactoServices)
        {
            _contactoServices = contactoServices;
        }
        public IActionResult Index()
        {
            var response = _contactoServices.getContactos();
            return View(response);
        }

        public IActionResult FormularioCrearContacto()
        {
  
            return View();
        }

        [HttpPost]
        public IActionResult CreateContacto(CreateContactoDTO contacto)
        {
  
            
            var response = _contactoServices.crearContacto(contacto);
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
