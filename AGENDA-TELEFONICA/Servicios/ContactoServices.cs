using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TODO_MVC_NETCORE.DTOs;
using TODO_MVC_NETCORE.Models;
using TODO_MVC_NETCORE.Servicios.Interfaces;

namespace TODO_MVC_NETCORE.Servicios
{
    public class ContactoServices : IContacto
    {
        private readonly AppDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ContactoServices(AppDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task <ResponseContactoDTO> getContacto(int idContacto)
        {
            var contacto = await _context.Contacto
                 .Where(c => c.Id == idContacto)
                 .Select(c => new ResponseContactoDTO(c))
                 .FirstOrDefaultAsync();

            return contacto;
        }

        public async Task <IEnumerable<ResponseContactoDTO>> getContactos(string idUser)
        {
            var listadoContactos = await _context.Contacto
                .Where(c => c.idUser.Equals(idUser))
                .Select(c => new ResponseContactoDTO(c))
                .ToListAsync();

            return listadoContactos;
        }

        public async Task <MensajeContactoDTO> borrarContacto( int idContacto ) 
        {
            var contacto = await _context.Contacto.Where(t => t.Id == idContacto).FirstOrDefaultAsync();

            if(contacto != null)
            {
                _context.Contacto.Remove(contacto);
                _context.SaveChanges();
                return new MensajeContactoDTO()
                {
                    estado = "Borrado",
                    Mensaje = $"El Contacto con el id: {idContacto} fue borrado correctamente"
                };
            }
            else
            {
                return new MensajeContactoDTO()
                {
                    estado = "Error",
                    Mensaje = $"El tablero con el id: {idContacto} no existe en la base de datos"
                };
            }
  
        }

        public async Task <bool> crearContacto(CreateContactoDTO nuevoContacto, string idUser)
        {
            var user = await _userManager.FindByIdAsync(idUser);

            var c = new Contacto()
            {
                NombreContacto = nuevoContacto.NombreContacto,
                ApellidoContacto = nuevoContacto.ApellidoContacto,
                TelefonoContacto = nuevoContacto.TelefonoContacto,
                FechaCreacionContacto = DateTime.Now,
                idUser = user.Id
            };

            var result = await _context.Contacto.AddAsync(c);
            _context.SaveChanges();
            return true;
        }

        public async Task <bool> updateContacto(UpdateContactoDTO uc)
        {
            var contacto = await _context.Contacto
                  .Where(c => c.Id == uc.Id)
                  .FirstOrDefaultAsync();

            if(contacto != null)
            {
                contacto.NombreContacto = uc.NombreContacto;
                contacto.ApellidoContacto = uc.ApellidoContacto;
                contacto.TelefonoContacto = uc.TelefonoContacto;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
