using System.Collections.Generic;
using Bleu.Mvc.Schema;

namespace Bleu.Mvc
{
    public interface IContentSource
    {
        IBlog GetBlog(int year, int month, int day, string title);

        int Count();

        IEnumerable<IBlog> GetPagedBlogs(int page, int pageSize);

        IEnumerable<IBlog> GetPagedBlogs(int page, int pageSize, bool oldestFirst);

        IEnumerable<IBlog> GetBlogs(int year);

        IEnumerable<IBlog> GetBlogs(int year, int month);

        IEnumerable<IBlog> GetBlogs(int year, int month, int day);
        
    }
}
