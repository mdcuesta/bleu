using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using Bleu.Mvc;
using Bleu.Mvc.Schema;

namespace Bleu.FileSystem
{
    public class ContentSource : IContentSource
    {
        private int? _count;

        public IBlog GetBlog(int year, int month, int day, string title)
        {
            var fileName = string.Format("{0}/{1}-{2:d2}-{3:d2}-{4}.txt", Settings.ArticlesPath, year, month, day, title);
            var absolutePath = HttpContext.Current.Server.MapPath(fileName);

            if (!File.Exists(absolutePath))
                return default(IBlog);

            var blog = new Blog(absolutePath);
            return blog;
        }

        public int Count()
        {
            if (!_count.HasValue)
            {
                var absolutePath = HttpContext.Current.Server.MapPath(Settings.ArticlesPath);
                if (!Directory.Exists(absolutePath))
                    throw new DirectoryNotFoundException("Articles Path");
                var info = new DirectoryInfo(absolutePath);
                _count = info.GetFiles().Count();
            }
            return _count.Value;            
        }

        public IEnumerable<IBlog> GetPagedBlogs(int page, int pageSize)
        {
            return GetPagedBlogs(page, pageSize, false);
        }

        public IEnumerable<IBlog> GetPagedBlogs(int page, int pageSize, bool oldestFirst)
        {
            var absolutePath = HttpContext.Current.Server.MapPath(Settings.ArticlesPath);
            if (!Directory.Exists(absolutePath))
                throw new DirectoryNotFoundException("Articles Path");

            var info = new DirectoryInfo(absolutePath);

            IEnumerable<FileInfo> files;
            if (oldestFirst)
                files = info.GetFiles().OrderBy(f => f.FullName).Skip((page - 1) * pageSize).Take(pageSize);
            else
                files = info.GetFiles().OrderByDescending(f => f.FullName).Skip((page - 1) * pageSize).Take(pageSize);

            foreach (var file in files)
            {
                yield return new Blog(file.FullName);
            }
        }

        public IEnumerable<IBlog> GetBlogs(int year)
        {
            var absolutePath = HttpContext.Current.Server.MapPath(Settings.ArticlesPath);
            if (!Directory.Exists(absolutePath))
                throw new DirectoryNotFoundException("Articles Path");

            var info = new DirectoryInfo(absolutePath);

            var files = info.GetFiles().Where(x => x.Name.StartsWith(year.ToString()));

            foreach (var file in files)
            {
                yield return new Blog(file.FullName);
            }
        }

        public IEnumerable<IBlog> GetBlogs(int year, int month)
        {
            var absolutePath = HttpContext.Current.Server.MapPath(Settings.ArticlesPath);
            if (!Directory.Exists(absolutePath))
                throw new DirectoryNotFoundException("Articles Path");

            var info = new DirectoryInfo(absolutePath);

            var files = info.GetFiles().Where(x => x.Name.StartsWith(string.Format("{0}-{1:d2}", year, month)));

            foreach (var file in files)
            {
                yield return new Blog(file.FullName);
            }
        }

        public IEnumerable<IBlog> GetBlogs(int year, int month, int day)
        {
            var absolutePath = HttpContext.Current.Server.MapPath(Settings.ArticlesPath);
            if (!Directory.Exists(absolutePath))
                throw new DirectoryNotFoundException("Articles Path");

            var info = new DirectoryInfo(absolutePath);

            var files = info.GetFiles().Where(x => x.Name.StartsWith(string.Format("{0}-{1:d2}-{2:d2}", year, month, day)));

            foreach (var file in files)
            {
                yield return new Blog(file.FullName);
            }
        }
    }
}
