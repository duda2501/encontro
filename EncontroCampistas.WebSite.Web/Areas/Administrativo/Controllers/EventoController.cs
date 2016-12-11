using EncontroCampistas.Biblioteca.Entidades;
using EncontroCampistas.Biblioteca.Repositorio;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EncontroCampistas.WebSite.Web.Areas.Administrativo.Controllers
{
    public class EventoController : Controller
    {
        private EventosRepositorio _repositorio;

        // GET: Administrativo/Evento
        public ActionResult Index()
        {
            _repositorio = new EventosRepositorio();
            var eventos = _repositorio.Eventos;
            return View(eventos);
        }


        public ViewResult Alterar(int eventoId)
        {
            _repositorio = new EventosRepositorio();
            Evento evento = _repositorio.Eventos
                .FirstOrDefault(e => e.EventoId == eventoId);

            return View(evento);
        }


        [HttpPost]
        public ActionResult Alterar(Evento evento, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                _repositorio = new EventosRepositorio();
                _repositorio.Salvar(evento);

                TempData["mensagem"] = string.Format("{0} foi salvo com sucesso", evento.Descricao);

                return RedirectToAction("Index");

            }
            return View(evento);
        }

        public ViewResult NovoEvento()
        {
            return View("Alterar", new Evento());
        }

        [HttpPost]
        public JsonResult Excluir(int eventoId)
        {
            // System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));

            string mensagem = string.Empty;
            _repositorio = new EventosRepositorio();

            Evento objEvento = _repositorio.Excluir(eventoId);

            if (objEvento != null)
            {
                mensagem = string.Format("{0} excluído com sucesso", objEvento.Descricao);
            }

            return Json(mensagem, JsonRequestBehavior.AllowGet);
        }
    }
}