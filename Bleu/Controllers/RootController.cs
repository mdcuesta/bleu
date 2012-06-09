using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bleu.Mvc;
using Bleu.Helpers;

namespace Bleu.Controllers
{
    public class RootController : BleuController
    {
        public ActionResult Index(int page)
        {
            ViewData.Add("page", page);

            var showOlderPosts = false;
            
            var pageSize = Settings.BlogsPageSize;
            var articleCount = ContentManager.ContentSource.Count();

            if (page * pageSize - articleCount > pageSize)
                return RedirectToAction("PageNotFound", "Root");

            if (page * pageSize < articleCount)
                showOlderPosts = true;

            var models = ContentManager.ContentSource.GetPagedBlogs(page, pageSize);

            ViewData.Add("showolderposts", showOlderPosts);
            ViewData.Add("shownewerposts", !(page == 1));
            return View("Index", models);
        }        

        public ActionResult About()
        {
            return View();
        }

        public ActionResult PageNotFound()
        {
            return View("404");
        }
    }
}