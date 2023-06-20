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

        //TODO: Se sobreescribe el método de la clase que se está heredando (DbContext).
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO:Valida si existen datos o no. En caso que no existan, va a
            //realizar un insert de un primer registro.
            modelBuilder.Entity<Amigo>().HasData(new Amigo 
            { 
                Id= 1, Nombre="NN", 
                Ciudad=Provincia.Bogota, 
                Email="email@correo.com",
                ProfilePictureUrl =""
            });            
        }

    }
}
