using TODO_MVC_NETCORE.DTOs;

namespace TODO_MVC_NETCORE.Servicios.Interfaces
{
    public interface IContacto
    {
        public Task <ResponseContactoDTO> getContacto(int idContacto);
        public Task <IEnumerable<ResponseContactoDTO>> getContactos(string idUser);
        public Task <MensajeContactoDTO> borrarContacto(int idContacto);
        public Task <bool> crearContacto(CreateContactoDTO nuevoContacto, string idUser);
        public Task <bool> updateContacto(UpdateContactoDTO uc);


    }
}
