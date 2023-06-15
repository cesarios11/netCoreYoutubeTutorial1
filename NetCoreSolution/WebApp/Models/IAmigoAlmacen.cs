using System.Collections.Generic;

namespace WebApp.Models
{
    public interface IAmigoAlmacen
    {
        Amigo dameDatosAmigo(int id);
        List<Amigo> dameTodosLosAmigos();
    }
}
