using System;
using Bleu.Mvc.Schema;
using Bleu.Mvc;
using System.Web;
using System.Linq;
using System.IO;
using System.Web.Mvc;

namespace Bleu.FileSystem
{
    class Blog : IBlog  
    {
        private string _previewContent;
        private string _content;
        private IBlog _previousBlog;
        private IBlog _nextBlog;

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
                if (_previousBlog == null)
                {
                    var directory = Path.GetDirectoryName(AbsolutePath);
                    var directoryInfo = new DirectoryInfo(directory);
                    var files = directoryInfo.GetFiles();
                    for (var i = 1; i < files.Length; i++)
                    {
                        if (AbsolutePath == files[i].FullName)
                            _previousBlog = new Blog(files[i - 1].FullName);
                    }
                }
                return _previousBlog;
            }
        }

        public IBlog NextBlog 
        {
            get
            {
                if (_nextBlog == null)
                {
                    var directory = Path.GetDirectoryName(AbsolutePath);
                    var directoryInfo = new DirectoryInfo(directory);
                    var files = directoryInfo.GetFiles();
                    for (var i = 0; i < files.Length - 1; i++)
                    {
                        if (AbsolutePath == files[i].FullName)
                            _nextBlog = new Blog(files[i + 1].FullName);
                    }
                }
                return _nextBlog;
            }
        }

        public string UniqueTitle { get; private set; }

        public string Title { get; private set; }

        public string Author { get; private set; }

        public DateTime Date { get; private set; }

        public bool PreviewTruncated { get; private set; }

        public string Content 
        {
            get
            {
                if (_content == null)
                {
                    if (!File.Exists(AbsolutePath))
                        return string.Empty;

                    var lines = File.ReadAllLines(AbsolutePath);
                    
                    for (var i = 3; i < lines.Length; i++)
                    {
                        _content += lines[i];
                    }                    
                }
                return _content;
            }
        }

        public string PreviewContent
        {
            get
            {
                if (_previewContent == null)
                {
                    if (!File.Exists(AbsolutePath))
                        return string.Empty;

                    var lines = File.ReadAllLines(AbsolutePath);

                    var content = string.Empty;

                    for (var i = 3; i < lines.Length; i++)
                    {
                        content += lines[i];

                        if (Settings.BlogPreviewLength == 0)
                            continue;
                        

                        if (content.Length > Settings.BlogPreviewLength)
                        {
                            PreviewTruncated = true;
                            _previewContent = content.Substring(0, Settings.BlogPreviewLength - 1);                           
                            return _previewContent;
                        }
                    }


                    if (!(Settings.BlogPreviewLength == 0))
                    {
                        if (content.Length > Settings.BlogPreviewLength)
                        {
                            PreviewTruncated = true;
                            _previewContent = content.Substring(0, Settings.BlogPreviewLength - 1);                                                       
                            return _previewContent;
                        }
                    }
                    else
                    {                        
                        _previewContent = content;                       
                    }
                }
                return _previewContent;
            }
        }
    }
}
