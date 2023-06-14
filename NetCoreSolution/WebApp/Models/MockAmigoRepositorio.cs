using System.Collections.Generic;
using System.Linq;

namespace WebApp.Models
{
    public class MockAmigoRepositorio : IAmigoAlmacen
    {
        private List<Amigo> amigosLista;

        public MockAmigoRepositorio()
        {
            amigosLista = new List<Amigo>();
            amigosLista.Add(new Amigo() { Id = 1, Nombre= "Pedro", Ciudad = "Madrid", Email="pedro@gmail.com"});
            amigosLista.Add(new Amigo() { Id = 2, Nombre = "Juan", Ciudad = "Toledo", Email = "juan@gmail.com" });
            amigosLista.Add(new Amigo() { Id = 3, Nombre = "Sara", Ciudad = "Cuenca", Email = "sara@gmail.com" });
        }
        public Amigo dameDatosAmigo(int id)
        {
            return this.amigosLista.FirstOrDefault(e => e.Id == id);
        }
    }
}
