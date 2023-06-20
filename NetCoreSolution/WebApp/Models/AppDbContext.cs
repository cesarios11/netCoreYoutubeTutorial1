using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
                
        }

        //TODO: Se ponen tantas propiedades como objetos de clases se tengan en el modelo
        public DbSet<Amigo> Amigos { get; set; }

    }
}
