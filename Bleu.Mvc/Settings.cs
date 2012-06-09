using Bleu.Mvc.Configuration;

namespace Bleu.Mvc
{
    public sealed class Settings
    {
        private static BleuConfiguration _configuration;

        private static BleuConfiguration Configuration
        {
            get
            {
                if(_configuration == null)
                {
                    if (BleuConfiguration.Default != null)
                        _configuration = BleuConfiguration.Default;
                    else
                    {
                        _configuration = new BleuConfiguration
                                             {
                                                ArticlesPath = "~/Articles",
                                                Author = "bleu blogger",
                                                ArticleViewsPath = "~/Views/Article"
                                             };
                    }


                }
                return _configuration;
            }
        }

        public static string Author { get { return Configuration.Author; } }

        public static string BlogTitle { get { return Configuration.BlogTitle; } }

        public static string BlogDescription { get { return Configuration.Description; } }

        public static string ArticlesPath { get { return Configuration.ArticlesPath; } }

        public static int BlogsPageSize { get { return Configuration.BlogsPageSize; } }

        public static string ArticleViewsPath { 
            get 
            { 
                return string.IsNullOrEmpty(Configuration.ArticleViewsPath) 
                        ? "~/Views/Article" 
                        : Configuration.ArticleViewsPath; 
            } 
        }

        public static string ArticleNotFoundView
        {
            get
            {
                return string.IsNullOrEmpty(Configuration.ArticleNotFoundView)
                        ? "~/Views/Article/ArticleNotFound.cshtml"
                        : Configuration.ArticleNotFoundView; 
            }
        }

    }
}
