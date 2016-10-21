using EncontroCampistas.Biblioteca.Entidades;
using System.Collections.Generic;

namespace EncontroCampistas.WebSite.Web.Models
{
    public class TipoEventoViewModel
    {
        public IEnumerable<TipoEvento> TipoEventos { get; set; }
    }
}