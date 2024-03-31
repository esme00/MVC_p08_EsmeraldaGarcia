using Microsoft.EntityFrameworkCore;

namespace MVC_p08_EsmeraldaGarcia.Models
{
    public class datosContext : DbContext
    {
        public datosContext(DbContextOptions<datosContext> options) : base(options)
        {

        }
        public DbSet<datos> datos { get; set; }

    }

}
