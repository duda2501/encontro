﻿using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EncontroCampistas.WebSite.Site.HtmlHelpers;
using EncontroCampistas.WebSite.Site.Models;

namespace EncontroCampistas.WebSite.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestarSeAPaginacaoEstaSendoGeradaCorretamente()
        {
            //Arrange

            HtmlHelper html = null;
            Paginacao paginacao = new Paginacao
            {
                PaginaAtual = 2,
                ItensPorPagina = 10,
                ItensTotal = 28
            };
            Func<int, string> paginaUrl = i => "Pagina" + i;
            //Act
            MvcHtmlString resultado = html.PageLinks(paginacao, paginaUrl);
            //Assert
            Assert.AreEqual(

                @"<a class=""btn btn-default"" href=""Pagina1"">1</a>"
                + @"<a class=""btn btn-default btn-primary selected"" href=""Pagina2"">2</a>"
                + @"<a class=""btn btn-default"" href=""Pagina3"">3</a>", resultado.ToString()

                );
        }
    }
}
