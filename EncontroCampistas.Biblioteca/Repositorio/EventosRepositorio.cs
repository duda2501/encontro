using EncontroCampistas.Biblioteca.Entidades;
using System.Collections.Generic;

namespace EncontroCampistas.Biblioteca.Repositorio
{
    public class EventosRepositorio
    {
        private readonly EFDbContext _context = new EFDbContext();

        public IEnumerable<Evento> Eventos
        {
            get { return _context.Eventos; }
        }
    }
}
