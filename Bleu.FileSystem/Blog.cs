using System;
using Bleu.Mvc.Schema;

namespace Bleu.FileSystem
{
    class Blog : IBlog  
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public DateTime Date { get; set; }
        
        public string Content { get; set; }

        public string Syntax { get; set; }
    }
}
