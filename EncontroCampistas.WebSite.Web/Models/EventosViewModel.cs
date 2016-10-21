using EncontroCampistas.Biblioteca.Entidades;
using EncontroCampistas.WebSite.Site.Models;
using System.Collections.Generic;

namespace EncontroCampistas.WebSite.Web.Models
{
    public class EventosViewModel
    {
        public IEnumerable<Evento> Eventos { get; set; }

        public Paginacao Paginacao { get; set; }

        public int EventoAtual { get; set; }
    }
}