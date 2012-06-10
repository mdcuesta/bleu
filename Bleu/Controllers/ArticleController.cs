using System.Web.Mvc;
using Bleu.Mvc;
using System.Linq;

namespace Bleu.Controllers
{
    public class ArticleController : BleuController
    {
        public ActionResult Show(int year, int month, int day, string title)
        {
            var blog = ContentManager.ContentSource.GetBlog(year, month, day, title);
            if (blog == null)
                RedirectToAction("PageNotFound", "Root");
            return View("Article", blog);
        }

        public ActionResult ListByDay(int year, int month, int day)
        {
            var blogs = ContentManager.ContentSource.GetBlogs(year, month, day);
            if (blogs.Count() < 1)
                RedirectToAction("PageNotFound", "Root");
            ViewData.Add("title", string.Format("{0}/{1:d2}/{2:d2} - Archive", year, month, day));
            return View("DayArticleArchive", blogs);
        }

        public ActionResult ListByMonth(int year, int month)
        {
            var blogs = ContentManager.ContentSource.GetBlogs(year, month);
            if (blogs.Count() < 1)
                RedirectToAction("PageNotFound", "Root");
            ViewData.Add("title", string.Format("{0}/{1:d2} - Archive", year, month));
            return View("MonthArticleArchive", blogs);            
        }

        public ActionResult ListByYear(int year)
        {
            var blogs = ContentManager.ContentSource.GetBlogs(year);
            if (blogs.Count() < 1)
                RedirectToAction("PageNotFound", "Root");
            ViewData.Add("title", string.Format("{0} - Archive", year));
            return View("YearArticleArchive", blogs);  
        }
    }
}