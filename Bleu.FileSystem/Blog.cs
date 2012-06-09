using System;
using Bleu.Mvc.Schema;
using System.Web;
using System.Linq;
using System.IO;

namespace Bleu.FileSystem
{
    class Blog : IBlog  
    {        
        private string AbsolutePath { get; set; }        

        public Blog(string path)
        {
            AbsolutePath = path;

            if (!File.Exists(AbsolutePath))
                return;

            using (var reader = File.OpenText(AbsolutePath))
            {
                Title = reader.ReadLine().Replace("title:", string.Empty).Trim();
                Author = reader.ReadLine().Replace("author:", string.Empty).Trim();
                var date = reader.ReadLine().Replace("date:", string.Empty).Trim();

                DateTime outDate;
                DateTime.TryParse(date, out outDate);
                Date = outDate;
            }      
      
            UniqueTitle = Path.GetFileNameWithoutExtension(AbsolutePath);
            UniqueTitle = UniqueTitle.Replace(string.Format("{0:d4}-{1:d2}-{2:d2}-", Date.Year, Date.Month, Date.Day), string.Empty);
        }

        public IBlog PreviousBlog
        {
            get
            {
                var directory = Path.GetDirectoryName(AbsolutePath);
                var directoryInfo = new DirectoryInfo(directory);
                var files = directoryInfo.GetFiles();
                for (var i = 1; i < files.Length; i++)
                {
                    if (AbsolutePath == files[i].FullName)
                        return new Blog(files[i - 1].FullName);                    
                }
                return null;
            }
        }

        public IBlog NextBlog 
        {
            get
            {
                var directory = Path.GetDirectoryName(AbsolutePath);
                var directoryInfo = new DirectoryInfo(directory);
                var files = directoryInfo.GetFiles();
                for (var i = 0; i < files.Length - 1; i++)
                {
                    if (AbsolutePath == files[i].FullName)
                        return new Blog(files[i + 1].FullName);
                }
                return null;
            }
        }

        public string UniqueTitle { get; private set; }

        public string Title { get; private set; }

        public string Author { get; private set; }

        public DateTime Date { get; private set; }

        public string Content 
        {
            get
            {
                if (!File.Exists(AbsolutePath))
                    return string.Empty;

                var lines = File.ReadAllLines(AbsolutePath);

                var content = string.Empty;
                for (var i = 3; i < lines.Length; i++)
                {
                    content += lines[i];
                }

                return content;
            }
        }

        public string PreviewContent
        {
            get
            {
                if (!File.Exists(AbsolutePath))
                    return string.Empty;

                var lines = File.ReadAllLines(AbsolutePath);

                var content = string.Empty;

                for(var i = 3; i < lines.Length; i++)
                {
                    content += lines[i];                    
                }

                return content;
            }
        }
    }
}
