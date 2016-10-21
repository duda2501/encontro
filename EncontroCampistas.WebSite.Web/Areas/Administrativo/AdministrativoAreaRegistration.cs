using System.Web.Mvc;

namespace EncontroCampistas.WebSite.Web.Areas.Administrativo
{
    public class AdministrativoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administrativo";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administrativo_default",
                "Administrativo/{controller}/{action}/{id}",
                new { controller="Evento", action = "Index", id = UrlParameter.Optional },
                new[] { "EncontroCampistas.WebSite.Web.Areas.Administrativo.Controllers" }
            );
        }
    }
}