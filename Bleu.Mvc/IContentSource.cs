using System.Collections.Generic;
using Bleu.Mvc.Schema;

namespace Bleu.Mvc
{
    public interface IContentSource
    {
        string GetContent(int year, int month, int day, string title);

        IEnumerable<IBlog> GetBlogs(int year);

        IEnumerable<IBlog> GetBlogs(int year, int month);

        IEnumerable<IBlog> GetBlogs(int year, int month, int day);
        
    }
}
