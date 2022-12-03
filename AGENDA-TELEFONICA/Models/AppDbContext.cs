using Microsoft.EntityFrameworkCore;

namespace TODO_MVC_NETCORE.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Contacto> Contacto { get; set; }
    }
}
