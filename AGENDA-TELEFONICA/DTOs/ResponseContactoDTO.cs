using TODO_MVC_NETCORE.Models;

namespace TODO_MVC_NETCORE.DTOs
{
    public class ResponseContactoDTO
    {
        public ResponseContactoDTO() { }
        public ResponseContactoDTO(Contacto c)
        {
            Id = c.Id;
            NombreContacto = c.NombreContacto;
            ApellidoContacto = c.ApellidoContacto;
            TelefonoContacto = c.TelefonoContacto;
            FechaCreacionContacto = c.FechaCreacionContacto;
        }
        public int Id { get; set; }
        public string NombreContacto { get; set; }
        public string ApellidoContacto { get; set; }
        public int TelefonoContacto { get; set; }
        public DateTime FechaCreacionContacto { get; set; }
    }
}
