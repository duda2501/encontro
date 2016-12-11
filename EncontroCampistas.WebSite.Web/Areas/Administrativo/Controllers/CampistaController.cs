using EncontroCampistas.Biblioteca.Entidades;
using EncontroCampistas.Biblioteca.Repositorio;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EncontroCampistas.WebSite.Web.Areas.Administrativo.Controllers
{
    public class CampistaController : Controller
    {
        private CampistasRepositorio _repositorio;

        // GET: Administrativo/Campista
        public ActionResult Index()
        {
            _repositorio = new CampistasRepositorio();
            var campistas = _repositorio.Campistas;
            return View(campistas);
        }


        public ViewResult Alterar(int campistaId)
        {
            _repositorio = new CampistasRepositorio();
            Campista campista = _repositorio.Campistas
                .FirstOrDefault(e => e.CampistaId == campistaId);

            return View(campista);
        }


        [HttpPost]
        public ActionResult Alterar(Campista campista, HttpPostedFileBase image = null)
        {
            if (ModelState.IsValid)
            {
                _repositorio = new CampistasRepositorio();
                _repositorio.Salvar(campista);

                TempData["mensagem"] = string.Format("{0} foi salvo com sucesso", campista.Nome);

                return RedirectToAction("Index");

            }
            return View(campista);
        }

        public ViewResult NovoCampista()
        {
            return View("Alterar", new Campista());
        }

        [HttpPost]
        public JsonResult Excluir(int campistaId)
        {
            // System.Threading.Thread.Sleep(TimeSpan.FromSeconds(5));

            string mensagem = string.Empty;
            _repositorio = new CampistasRepositorio();

            Campista objCampista = _repositorio.Excluir(campistaId);

            if (objCampista != null)
            {
                mensagem = string.Format("{0} excluído com sucesso", objCampista.Nome);
            }

            return Json(mensagem, JsonRequestBehavior.AllowGet);
        }
    }
}