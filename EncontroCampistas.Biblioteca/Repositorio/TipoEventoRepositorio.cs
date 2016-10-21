using EncontroCampistas.Biblioteca.Entidades;
using System.Collections.Generic;

namespace EncontroCampistas.Biblioteca.Repositorio
{
    public class TipoEventoRepositorio
    {
        private readonly EFDbContext _context = new EFDbContext();

        public IEnumerable<TipoEvento> TipoEventos
        {
            get { return _context.TipoEventos; }
        }
    }
}
