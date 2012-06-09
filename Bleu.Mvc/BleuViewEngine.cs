using System.IO;
using System.Web;
using System.Web.Mvc;
using Bleu.Mvc.Schema;

namespace Bleu.Mvc
{
    public class BleuViewEngine : RazorViewEngine
    {
        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            #region Commented
            //var controllerName = controllerContext.RouteData.GetRequiredString("controller");
            //if(controllerName.ToLower() == "article")
            //{
            //    var action = controllerContext.RouteData.Values["action"];

            //    if (action.ToString().ToLower() == "show")
            //    {
            //        var path = string.Format("{0}/{1}.cshtml", Settings.ArticleViewsPath, viewName);
            //        if (!FileExists(controllerContext, path))
            //        {
            //            var segments = viewName.Split('-');
                        
            //            var year = int.Parse(segments[0]);
            //            var month = int.Parse(segments[1]);
            //            var day = int.Parse(segments[2]);

            //            var title = string.Empty;
            //            for(var i = 3; i < segments.Length; i++)
            //            {
            //                title = (i == 3)
            //                    ? segments[i]
            //                    : string.Format("{0}-{1}", title, segments[i]);
            //            }

            //            var blog = ContentManager.ContentSource.GetBlog(year, month, day, title);

            //            if (blog == default(IBlog))
            //            {                            
            //                var view = CreateView(controllerContext, Settings.ArticleNotFoundView, "");                           
            //                return new ViewEngineResult(view, this);
            //            }                        

            //            var diskPath = HttpContext.Current.Server.MapPath(path);

            //            var articleTemplate = string.Format("{0}/{1}", Settings.ArticleViewsPath, "ArticleViewTemplate.cshtml");

            //            if(!FileExists(controllerContext, articleTemplate))
            //                throw new FileNotFoundException("Unable to locate ArticleViewTemplate.cshtml");

            //            var templateDiskPath = HttpContext.Current.Server.MapPath(articleTemplate);
            //            var templateText = File.ReadAllText(templateDiskPath);
            //            templateText = templateText.Replace("<!--Title-->", blog.Title ?? string.Empty);
            //            templateText = templateText.Replace("<!--Date-->", blog.Date.ToLongDateString());

            //            if (blog.NextBlog != null)
            //            {
            //                var link = string.Format("{0}/{1:d2}/{2:d2}/{3}",
            //                    blog.NextBlog.Date.Year, blog.NextBlog.Date.Month,
            //                    blog.NextBlog.Date.Day, blog.NextBlog.UniqueTitle);

            //                templateText = templateText.Replace("<!--PreviousBlogLink-->", link);
            //                templateText = templateText.Replace("<!--PreviousBlogTitle--> ", blog.NextBlog.Title);
            //            }

            //            var content = templateText.Replace("<!--Content-->", blog.Content ?? string.Empty);

            //            File.WriteAllText(diskPath, content);
            //        }
            //    }
            //}
            #endregion
            
            return base.FindView(controllerContext, viewName, masterName, useCache);
        }
    }
}
