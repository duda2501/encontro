using EncontroCampistas.Biblioteca.Repositorio;
using EncontroCampistas.WebSite.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace EncontroCampistas.WebSite.Web.Controllers
{
    public class EventosController : Controller
    {
        private EventosRepositorio _repositorio;
        public int EventosPorPagina = 5;
        // GET: Eventos
        public ViewResult ListaEventos(int tipoEvento = -1, int pagina = 1)
        {
            _repositorio = new EventosRepositorio();

            EventosViewModel model = new EventosViewModel
            {
                Eventos = _repositorio.Eventos
                .Where(e => tipoEvento == -1 || e.TipoEvento == tipoEvento)
                .OrderBy(e => e.Descricao)
                .Skip((pagina - 1) * EventosPorPagina)
                .Take(EventosPorPagina),

                Paginacao = new Site.Models.Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = EventosPorPagina,
                    ItensTotal = _repositorio.Eventos.Count()
                },

                EventoAtual = tipoEvento
            };

            return View(model);
        }
    }
}