﻿using System.Configuration;

namespace Bleu.Mvc.Configuration
{
    public class BleuConfiguration : ConfigurationSection
    {
        [ConfigurationProperty("author")]
        public string Author
        {
            get { return (this["author"] ?? "bleu blogger").ToString(); }
            set { this["author"] = value; }
        }

        [ConfigurationProperty("articlespath")]
        public string ArticlesPath
        {
            get { return (string)this["articlespath"]; }
            set { this["articlespath"] = value; }
        }

        [ConfigurationProperty("articleviewspath")]
        public string ArticleViewsPath
        {
            get { return (string) this["articleviewspath"] ?? "~/Views/Article"; }
            set { this["articleviewspath"] = value; }
        }

        [ConfigurationProperty("articlenotfoundview")]
        public string ArticleNotFoundView
        {
            get { return (string)this["articlenotfoundview"] ?? "~/Views/Article/ArticleNotFound.cshtml"; }
            set { this["articlenotfoundview"] = value; }
        }

        internal static BleuConfiguration Default
        {
            get 
            { 
                var section = ConfigurationManager.GetSection("bleu.configuration");
                if (section == null)
                    return null;

                if (section is BleuConfiguration)
                    return section as BleuConfiguration;
                return null;
            }
        }
    }
}
