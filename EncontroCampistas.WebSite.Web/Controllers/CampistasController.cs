using EncontroCampistas.Biblioteca.Repositorio;
using EncontroCampistas.WebSite.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace EncontroCampistas.WebSite.Web.Controllers
{
    public class CampistasController : Controller
    {
        private CampistasRepositorio _repositorio;
        public int CampistasPorPagina = 5;
        // GET: Campistas
        public ViewResult ListaCampistas(int pagina = 1)
        {
            _repositorio = new CampistasRepositorio();

            CampistasViewModel model = new CampistasViewModel
            {
                Campistas = _repositorio.Campistas
                .OrderBy(c => c.Nome)
                .Skip((pagina - 1) * CampistasPorPagina)
                .Take(CampistasPorPagina),

                Paginacao = new Site.Models.Paginacao
                {
                    PaginaAtual = pagina,
                    ItensPorPagina = CampistasPorPagina,
                    ItensTotal = _repositorio.Campistas.Count()
                }
            };

            return View(model);
        }
    }
}