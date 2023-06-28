using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApp.ViewModels;

namespace WebApp.Models
{
    //TODO: La clase de la cual heredaba antes 'AppDbContext' era 'DbContext'.
    //'DbContext' hereda de 'IdentityDbContext' por lo cual no hay problema en decirle a 'AppDbContext' que herede de esta última
    // La clase 'IdentityDbContext' ahora hale de la clase 'UsuarioAplicacion'
    public class AppDbContext : IdentityDbContext<UsuarioAplicacion>
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
            /*
            modelBuilder.Entity<Amigo>().HasData(new Amigo 
            { 
                Id= 1, Nombre="NN", 
                Ciudad=Provincia.Bogota, 
                Email="email@correo.com",
                ProfilePictureUrl =""
            });
            */

            base.OnModelCreating(modelBuilder);

            //TODO:Recorre todas las llaves foráneas que existen y deshabilita el borrado en cascada y lo pone como Restrict.
            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

    }
}
