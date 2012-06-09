using System.Configuration;

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

        #region Commented
        //[ConfigurationProperty("articleviewspath")]
        //public string ArticleViewsPath
        //{
        //    get { return (string) this["articleviewspath"] ?? "~/Views/Article"; }
        //    set { this["articleviewspath"] = value; }
        //}

        //[ConfigurationProperty("articlenotfoundview")]
        //public string ArticleNotFoundView
        //{
        //    get { return (string)this["articlenotfoundview"] ?? "~/Views/Article/ArticleNotFound.cshtml"; }
        //    set { this["articlenotfoundview"] = value; }
        //}
        #endregion

        [ConfigurationProperty("blogtitle")]
        public string BlogTitle
        {
            get { return (string)this["blogtitle"] ?? string.Empty; }
            set { this["blogtitle"] = value; }
        }

        [ConfigurationProperty("description")]
        public string Description
        {
            get { return (string)this["description"] ?? string.Empty; }
            set { this["description"] = value; }
        }

        [ConfigurationProperty("blogspagesize")]
        public int BlogsPageSize
        {
            get 
            {
                int val = 10;
                var configValue = (this["blogspagesize"] ?? "10").ToString();
                int.TryParse(configValue, out val);                
                return val;
            }
            set { this["blogspagesize"] = value; }
        }

        [ConfigurationProperty("blogpreviewlength")]
        public int BlogPreviewLength
        {
            get
            {
                int val = 2000;
                var configValue = (this["blogpreviewlength"] ?? "2000").ToString();
                int.TryParse(configValue, out val);
                return val;
            }
            set { this["blogpreviewlength"] = value; }
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
