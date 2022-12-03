using TODO_MVC_NETCORE.DTOs;

namespace TODO_MVC_NETCORE.Servicios.Interfaces
{
    public interface IContacto
    {
        public ResponseContactoDTO getContacto(int idContacto);
        public IEnumerable<ResponseContactoDTO> getContactos();
        public MensajeContactoDTO borrarContacto(int idContacto);
        public bool crearContacto(CreateContactoDTO nuevoContacto);
        public bool updateContacto(UpdateContactoDTO uc);


    }
}
