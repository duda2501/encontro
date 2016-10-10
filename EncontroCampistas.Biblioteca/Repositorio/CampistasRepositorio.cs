using EncontroCampistas.Biblioteca.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
