using System.ComponentModel.DataAnnotations;

namespace TODO_MVC_NETCORE.DTOs
{
    public class CreateContactoDTO
    {
        public string NombreContacto { get; set; }
        public string ApellidoContacto { get; set; }
        public int TelefonoContacto { get; set; }
    }
}
