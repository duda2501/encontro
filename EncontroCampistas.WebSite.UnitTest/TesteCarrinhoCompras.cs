using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EncontroCampistas.Biblioteca.Entidades;
using System.Collections.Generic;

namespace EncontroCampistas.WebSite.UnitTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        //Teste Acionar Itens ao Carrinho
        [TestMethod]
        public void AdicionarItensAoCarrinho()
        {
            //Arrange - criação dos Eventos
            Evento Evento1 = new Evento
            {
                EventoId = 1,
                Descricao = "Teste 1"
            };

            Evento Evento2 = new Evento
            {
                EventoId = 2,
                Descricao = "Teste 2"
            };

            Evento Evento3 = new Evento
            {
                EventoId = 3,
                Descricao = "Teste 3"
            };

            //Act
            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarEvento(Evento1);
            carrinho.AdicionarEvento(Evento2);
            carrinho.AdicionarEvento(Evento3);

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Count, 3);
            Assert.AreEqual(carrinho.ItensCarrinho[0], Evento1);
            Assert.AreEqual(carrinho.ItensCarrinho[1], Evento2);
        }


        [TestMethod]
        public void AdicionarEventoExistenteParaCarrinho()
        {
            //Arrange - criação dos Eventos
            Evento Evento1 = new Evento
            {
                EventoId = 1,
                Descricao = "Teste 1"
            };

            Evento Evento2 = new Evento
            {
                EventoId = 2,
                Descricao = "Teste 2"
            };

            //Arrange
            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarEvento(Evento1);
            carrinho.AdicionarEvento(Evento2);
            carrinho.AdicionarEvento(Evento1);

            //Act
            Assert.AreEqual(carrinho.ItensCarrinho.Count, 2);
        }


        [TestMethod]
        public void RemoverItensCarrinho()
        {
            //Arrange - criação dos Eventos
            Evento Evento1 = new Evento
            {
                EventoId = 1,
                Descricao = "Teste 1"
            };

            Evento Evento2 = new Evento
            {
                EventoId = 2,
                Descricao = "Teste 2"
            };

            Evento Evento3 = new Evento
            {
                EventoId = 3,
                Descricao = "Teste 3"
            };


            Carrinho carrinho = new Carrinho();

            carrinho.AdicionarEvento(Evento1);
            carrinho.AdicionarEvento(Evento2);
            carrinho.AdicionarEvento(Evento3);
            carrinho.AdicionarEvento(Evento2);
            carrinho.RemoverEvento(Evento2);

            Assert.AreEqual(carrinho.ItensCarrinho.Count, 2);
        }


        [TestMethod]
        public void LimparIntesCarrinho()
        {
            Evento Evento1 = new Evento
            {
                EventoId = 1,
                Descricao = "Teste 1"
            };

            Evento Evento2 = new Evento
            {
                EventoId = 2,
                Descricao = "Teste 2"
            };


            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarEvento(Evento1);
            carrinho.AdicionarEvento(Evento2);
            carrinho.LimparCarrinho();

            //Assert
            Assert.AreEqual(carrinho.ItensCarrinho.Count, 0);
        }
    }
}
