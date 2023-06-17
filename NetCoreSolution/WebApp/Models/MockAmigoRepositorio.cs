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
            amigosLista.Add(new Amigo() { Id = 1, Nombre= "Pedro", Ciudad = Provincia.Bogota, ProfilePictureUrl= "https://img.resized.co/siliconrepublic/eyJkYXRhIjoie1widXJsXCI6XCJodHRwczpcXFwvXFxcL3d3dy5zaWxpY29ucmVwdWJsaWMuY29tXFxcL3dwLWNvbnRlbnRcXFwvdXBsb2Fkc1xcXC8yMDIzXFxcLzAzXFxcL0Fkb2JlU3RvY2tfNTUwNDU2NTQxLmpwZWdcIixcIndpZHRoXCI6MTEwMCxcImhlaWdodFwiOjYwMCxcImRlZmF1bHRcIjpcImh0dHBzOlxcXC9cXFwvd3d3LnNpbGljb25yZXB1YmxpYy5jb21cXFwvd3AtY29udGVudFxcXC91cGxvYWRzXFxcLzIwMTRcXFwvMTJcXFwvMjAxMzAyXFxcL3B1enpsZS5qcGdcIixcIm9wdGlvbnNcIjpbXX0iLCJoYXNoIjoiNzFjNDNhZGE4N2MzOTllMWM1NWU2YjkwOTM4NGM1MDI2NzVhNGU5NyJ9/adobestock-550456541.jpeg", Email="pedro@gmail.com"});
            amigosLista.Add(new Amigo() { Id = 2, Nombre = "Juan", Ciudad = Provincia.Bucaramanga, ProfilePictureUrl= "https://ichef.bbci.co.uk/images/ic/448xn/p0738jgw.jpg", Email = "juan@gmail.com" });
            amigosLista.Add(new Amigo() { Id = 3, Nombre = "Sara", Ciudad = Provincia.Cali, ProfilePictureUrl= "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQP4cZNptAFfqICoWFdssOLCRJNeq3nUxr0uqxRm28l2nc_pq-n9wJkIHRpnluLn9lV6ow&usqp=CAU", Email = "sara@gmail.com" });
        }
        public Amigo dameDatosAmigo(int id)
        {
            return this.amigosLista.FirstOrDefault(e => e.Id == id);
        }

        public List<Amigo> dameTodosLosAmigos()
        {
            return amigosLista;
        }

        public Amigo nuevo(Amigo amigo)
        {
            amigo.Id = amigosLista.Max(x => x.Id) + 1;
            amigosLista.Add(amigo);
            return amigo;
        }
    }
}
