using System.Collections.Generic;
using System.Linq;

namespace WebApp.Models
{
    public class SQLAmigoRepositorio : IAmigoAlmacen
    {
        private readonly AppDbContext _context;
        private List<Amigo> amigosLista;
        public SQLAmigoRepositorio(AppDbContext context)
        {
            this._context = context;       
        }

        public Amigo nuevo(Amigo amigo)
        {
            _context.Amigos.Add(amigo);
            _context.SaveChanges();
            return amigo;
        }

        public Amigo borrar(int id)
        {
            Amigo amigo = _context.Amigos.Find(id);
            if (amigo != null)
            {
                _context.Amigos.Remove(amigo);
                _context.SaveChanges();
            }
            return amigo;
        }

        public List<Amigo> dameTodosLosAmigos()
        {
            return _context.Amigos.ToList<Amigo>();
        }

        public Amigo dameDatosAmigo(int id)
        {
            return _context.Amigos.Find(id);
        }       

        public Amigo modificar(Amigo amigo)
        {
            var _amigo = _context.Amigos.Attach(amigo);
            _amigo.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return amigo;
        }

      
    }
}
