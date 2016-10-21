using EncontroCampistas.Biblioteca.Entidades;
using System.Collections.Generic;

namespace EncontroCampistas.Biblioteca.Repositorio
{
    public class CampistasRepositorio
    {
        private readonly EFDbContext _context = new EFDbContext();

        public IEnumerable<Campista> Campistas
        {
            get { return _context.Campistas; }
        }
    }
}
