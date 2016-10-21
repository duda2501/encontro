using EncontroCampistas.Biblioteca.Entidades;
using EncontroCampistas.WebSite.Site.Models;
using System.Collections.Generic;

namespace EncontroCampistas.WebSite.Web.Models
{
    public class CampistasViewModel
    {
        public IEnumerable<Campista> Campistas { get; set; }

        public Paginacao Paginacao { get; set; }
    }
}