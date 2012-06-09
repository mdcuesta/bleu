using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;

namespace Bleu.Disqus
{
    public static class DisqusHelper 
    {
        public static IHtmlString DisqusComment(this HtmlHelper helper)
        {
            var settingsValue = System.Configuration.ConfigurationManager.AppSettings["disqusid"];
            var linkFormat = 
                "<script type=\"text/javascript\" src=\"http://disqus.com/forums/{0}/embed.js\"></script><noscript><a href=\"http://{1}.disqus.com/?url=ref\">View the discussion thread.</a></noscript><a href=\"http://disqus.com\" class=\"dsq-brlink\">blog comments powered by <span class=\"logo-disqus\">Disqus</span></a>";

            if (!string.IsNullOrEmpty(settingsValue))
            {          
                return MvcHtmlString.Create(string.Format(linkFormat, settingsValue, settingsValue));
            }
            return MvcHtmlString.Create(string.Empty);
        }
    }
}
