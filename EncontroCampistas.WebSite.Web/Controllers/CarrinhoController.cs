using EncontroCampistas.Biblioteca.Entidades;
using EncontroCampistas.Biblioteca.Repositorio;
using EncontroCampistas.WebSite.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EncontroCampistas.WebSite.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private EventosRepositorio _repositorio;

        // GET: Carrinho
        public RedirectToRouteResult Adicionar(int eventoId, string returnURL)
        {
            _repositorio = new EventosRepositorio();

            Evento evento = _repositorio.Eventos.
                FirstOrDefault(e => e.EventoId == eventoId);

            if (evento != null)
            {
                ObterCarrinho().AdicionarEvento(evento);
            }

            return RedirectToAction("Index", new { returnURL });
        }

        private Carrinho ObterCarrinho()
        {
            Carrinho carrinho = (Carrinho)Session["Carrinho"];

            if (carrinho==null)
            {
                carrinho = new Carrinho();
                Session["Carrinho"] = carrinho;
            }

            return carrinho;
        }

        public RedirectToRouteResult Remover(int eventoId, string returnURL)
        {
            _repositorio = new EventosRepositorio();

            Evento evento = _repositorio.Eventos.
                FirstOrDefault(e => e.EventoId == eventoId);

            if (evento != null)
            {
                ObterCarrinho().RemoverEvento(evento);
            }

            return RedirectToAction("Index", new { returnURL });
        }

        public ViewResult Index(string returnURL)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = ObterCarrinho(),
                ReturnUrl = returnURL
            });
        }

        public ViewResult FecharPedido()
        {
            return View(new Pedido());
        }

        [HttpPost]
        public ViewResult FecharPedido(Pedido pedido)
        {
            Carrinho carrinho = ObterCarrinho();

            EmailConfiguracoes email = new EmailConfiguracoes
            {
                EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.EscreverArquivo"] ?? "false")
            };

            EmailPedido emailPedido = new EmailPedido(email);

            if (!carrinho.ItensCarrinho.Any())
            {
                ModelState.AddModelError("", "Não foi possível concluir o pedido, seu carrinho está vazio!");
            }

            if (ModelState.IsValid)
            {
                emailPedido.ProcessarPedido(carrinho, pedido);
                carrinho.LimparCarrinho();
                return View("PedidoConcluido");
            }
            else
            {
                return View(pedido);
            }
        }

        public PartialViewResult Resumo()
        {
            Carrinho carrinho = ObterCarrinho();
            return PartialView(carrinho);
        }


        public ViewResult PedidoConcluido()
        {
            return View();
        }
    }
}