using Microsoft.EntityFrameworkCore;
using TODO_MVC_NETCORE.DTOs;
using TODO_MVC_NETCORE.Models;
using TODO_MVC_NETCORE.Servicios.Interfaces;

namespace TODO_MVC_NETCORE.Servicios
{
    public class ContactoServices : IContacto
    {
        private readonly AppDbContext _context;
        public ContactoServices(AppDbContext context)
        {
            _context = context;
        }

        public ResponseContactoDTO getContacto(int idContacto)
        {
            var contacto = _context.Contacto
                 .Where(c => c.Id == idContacto)
                 .Select(c => new ResponseContactoDTO(c))
                 .FirstOrDefault();

            return contacto;
        }

        public IEnumerable<ResponseContactoDTO> getContactos()
        {
            var listadoContactos = _context
                .Contacto
                .Select(c => new ResponseContactoDTO(c))
                .ToList();

            return listadoContactos;
        }

        public MensajeContactoDTO borrarContacto( int idContacto ) 
        {
            var contacto = _context.Contacto.Where(t => t.Id == idContacto).FirstOrDefault();

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

        public bool crearContacto(CreateContactoDTO nuevoContacto)
        {

            var c = new Contacto()
            {
                NombreContacto = nuevoContacto.NombreContacto,
                ApellidoContacto = nuevoContacto.ApellidoContacto,
                TelefonoContacto = nuevoContacto.TelefonoContacto,
                FechaCreacionContacto = DateTime.Now
            };

            var result = _context.Contacto.Add(c);
            _context.SaveChanges();
            return true;
        }

        public bool updateContacto(UpdateContactoDTO uc)
        {
            var contacto = _context.Contacto
                  .Where(c => c.Id == uc.Id)
                  .FirstOrDefault();
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
