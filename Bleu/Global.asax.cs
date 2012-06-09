using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Bleu.FileSystem;
using Bleu.Mvc;

namespace Bleu
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "About",
                "about",
                new { controller = "Root", action = "About" }
                );

            routes.MapRoute(
                "404",
                "Error404",
                new { controller = "Root", action = "PageNotFound" }
                );

            routes.MapRoute(
                "Root",
                "",
                new { controller = "Root", action = "Index", page = "1" }
                );

            routes.MapRoute(
                "Index",
                "index",
                new { controller = "Root", action = "Index", page = "1" }
                );

            routes.MapRoute(
                "Home",
                "home",
                new { controller = "Root", action = "Index", page = "1" }
                );

            routes.MapRoute(
                "IndexPaged",
                "{page}",
                new { controller = "Root", action = "Index"}
                );

            

            routes.MapRoute(
                "Article",
                "{year}/{month}/{day}/{title}",
                new { controller = "Article", action = "Show" },
                new { year = @"\d{2}|\d{4}", month = @"\d{1,2}", day = @"\d{1,2}" }
                );

            routes.MapRoute(
                "ListArticleByDay",
                "{year}/{month}/{day}",
                new { controller = "Article", action = "ListByDay" },
                new { year = @"\d{2}|\d{4}", month = @"\d{1,2}", day = @"\d{1,2}" }
                );
            
            routes.MapRoute(
                "ListArticleByMonth",
                "{year}/{month}",
                new { controller = "Article", action = "ListByMonth" },
                new { year = @"\d{2}|\d{4}", month = @"\d{1,2}" }
                );

            routes.MapRoute(
                "ListArticleByYear",
                "{year}",
                new { controller = "Article", action = "ListByYear" },
                new { year = @"\d{2}|\d{4}" }
                );
        }

        protected void Application_Start()
        {
            //Add Customized View Engine
            var viewEngine = new BleuViewEngine();
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(viewEngine);

            var contentSource = new ContentSource();
            ContentManager.SetContentSource(contentSource);

            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}