using System.Web.Mvc;
using Bleu.Mvc;

namespace Bleu.Controllers
{
    public class ArticleController : BleuController
    {
        public ActionResult Show(int year, int month, int day, string title)
        {
            return ArticleView(year, month, day, title);
        }

        public ActionResult ListByDay(int year, int month, int day)
        {
            return View();
        }

        public ActionResult ListByMonth(int year, int month)
        {
            return View();
        }

        public ActionResult ListByYear(int year)
        {
            return View();
        }
    }
}