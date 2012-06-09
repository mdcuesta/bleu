﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Bleu.Disqus
{
    public static class DisqusHelper 
    {
        public static string DisqusComment(this HtmlHelper helper)
        {
            var settingsValue = System.Configuration.ConfigurationManager.AppSettings["disqusid"];
            var linkFormat = 
                "<script type=\"text/javascript\" src=\"http://disqus.com/forums/{0}/embed.js\"></script><noscript><a href=\"http://{1}.disqus.com/?url=ref\">View the discussion thread.</a></noscript>";

            if (!string.IsNullOrEmpty(settingsValue))
            {
                return string.Format(linkFormat, settingsValue, settingsValue);
            }
            return string.Empty;
        }
    }
}
