using System.Web.Mvc;
using System.Web.Routing;

namespace EncontroCampistas.WebSite.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // 1 - Todos Eventos
            routes.MapRoute(null, "", new { controller = "Eventos", action = "ListaEventos", tipoEvento = -1, pagina = 1 });

            // 2 - Paginação
            routes.MapRoute(null, "Pagina{pagina}", new { controller = "Eventos", Action = "ListaEventos", tipoEvento = (int)-1 }, new { pagina = @"\d+" });

            // 3 - Eventos sem paginação
            routes.MapRoute(null, "{tipoEvento}", new { controller = "Eventos", action = "ListaEventos", pagina = 1 });

            // 4 - Eventos e paginação
            routes.MapRoute(null, "{tipoEvento}/Pagina{pagina}", new { Controller = "Eventos", Action = "ListaEventos" }, new { pagina = @"\d+" });

            routes.MapRoute(name: null, url: "Pagina{pagina}", defaults: new { controller = "Campistas", Action = "ListaCampistas" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Campistas", action = "ListaCampistas", id = UrlParameter.Optional }
            );
        }
    }
}
