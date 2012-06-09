using System;

namespace Bleu.Mvc.Schema
{
    public interface IBlog
    {
        IBlog PreviousBlog { get; }

        IBlog NextBlog { get; }

        string UniqueTitle { get; }

        string Title { get; }

        string Author { get; }

        DateTime Date { get; }

        string Content { get; }

        string PreviewContent { get; }

        bool PreviewTruncated { get; }
    }
}