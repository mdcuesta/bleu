using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bleu.Mvc;
using Bleu.Mvc.Schema;

namespace Bleu.Helpers
{
    public static class BleuHelper
    {
        public static string Title(this HtmlHelper helper)
        {
            return Settings.BlogTitle;
        }

        public static string Description(this HtmlHelper helper)
        {
            return Settings.BlogDescription;
        }

        public static IEnumerable<IBlog> PagedBlogs(int page, int pageSize, bool oldestFirst)
        {
            return ContentManager.ContentSource.GetPagedBlogs(page, pageSize, oldestFirst);
        }

        public static int BlogCount()
        {
            return ContentManager.ContentSource.Count();
        }
    }
}