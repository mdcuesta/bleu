using System.IO;
using System.Collections.Generic;
using System.Web;
using Bleu.Mvc;
using Bleu.Mvc.Schema;

namespace Bleu.FileSystem
{
    public class ContentSource : IContentSource
    {
        public string GetContent(int year, int month, int day, string title)
        {
            var fileName = string.Format("{0}/{1}-{2:d2}-{3:d2}-{4}.txt", Settings.ArticlesPath, year, month, day, title);
            var absolutePath = HttpContext.Current.Server.MapPath(fileName);
            
            return (!File.Exists(absolutePath))
                ? string.Empty
                : File.ReadAllText(absolutePath);
        }

        public IEnumerable<IBlog> GetBlogs(int year)
        {
            return default(IEnumerable<IBlog>);
        }

        public IEnumerable<IBlog> GetBlogs(int year, int month)
        {
            return default(IEnumerable<IBlog>);
        }

        public IEnumerable<IBlog> GetBlogs(int year, int month, int day)
        {
            return default(IEnumerable<IBlog>);
        }
    }
}
