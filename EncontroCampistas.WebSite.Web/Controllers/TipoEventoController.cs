using EncontroCampistas.Biblioteca.Entidades;
using EncontroCampistas.Biblioteca.Repositorio;
using EncontroCampistas.WebSite.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace EncontroCampistas.WebSite.Web.Controllers
{
    public class TipoEventoController : Controller
    {
        private TipoEventoRepositorio _repositorio;

        // GET: TipoEvento
        public PartialViewResult Menu(int tipoEvento = -1)
        {
            ViewBag.tipoEventoSelecionado = tipoEvento;

            _repositorio = new TipoEventoRepositorio();

            TipoEventoViewModel model = new TipoEventoViewModel
            {
                TipoEventos = _repositorio.TipoEventos
                .OrderBy(t => t.DescricaoTipoEvento),
            };

            return PartialView(model);
        }
    }
}