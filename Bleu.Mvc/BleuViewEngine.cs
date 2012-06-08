using System.IO;
using System.Web;
using System.Web.Mvc;

namespace Bleu.Mvc
{
    public class BleuViewEngine : RazorViewEngine
    {
        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            var controllerName = controllerContext.RouteData.GetRequiredString("controller");
            if(controllerName.ToLower() == "article")
            {
                var action = controllerContext.RouteData.Values["action"];

                if (action.ToString().ToLower() == "show")
                {
                    var path = string.Format("{0}/{1}.cshtml", Settings.ArticleViewsPath, viewName);
                    if (!FileExists(controllerContext, path))
                    {
                        var segments = viewName.Split('-');
                        
                        var year = int.Parse(segments[0]);
                        var month = int.Parse(segments[1]);
                        var day = int.Parse(segments[2]);

                        var title = string.Empty;
                        for(var i = 3; i < segments.Length; i++)
                        {
                            title = (i == 3)
                                ? segments[i]
                                : string.Format("{0}-{1}", title, segments[i]);
                        }

                        var content = ContentManager.ContentSource.GetContent(year, month, day, title);

                        if(string.IsNullOrEmpty(content))
                        {
                            var view = CreateView(controllerContext, Settings.ArticleNotFoundView, "");
                            return new ViewEngineResult(view, this);
                        }


                        var diskPath = HttpContext.Current.Server.MapPath(path);

                        var articleTemplate = string.Format("{0}/{1}", Settings.ArticleViewsPath, "ArticleViewTemplate.cshtml");

                        if(!FileExists(controllerContext, articleTemplate))
                            throw new FileNotFoundException("Unable to locate ArticleViewTemplate.cshtml");

                        var templateDiskPath = HttpContext.Current.Server.MapPath(articleTemplate);
                        var templateText = File.ReadAllText(templateDiskPath);
                        content = templateText.Replace("<!--Content-->", content);

                        File.WriteAllText(diskPath, content);
                    }
                }
            }
            
            return base.FindView(controllerContext, viewName, masterName, useCache);
        }
    }
}
