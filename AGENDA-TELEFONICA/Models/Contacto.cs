using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TODO_MVC_NETCORE.Models
{
    public class Contacto
    {
        public int Id { get; set; }
        public string NombreContacto { get; set; }
        public string ApellidoContacto { get; set; }
        public int TelefonoContacto { get; set; }
        public DateTime FechaCreacionContacto { get; set; }

        [Required]
        [ForeignKey("User")]
        public string idUser { get; set; }

        public virtual IdentityUser User { get; set; }

    }
}
