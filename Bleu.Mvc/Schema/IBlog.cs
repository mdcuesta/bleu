using System;

namespace Bleu.Mvc.Schema
{
    public interface IBlog
    {
        string Title { get; }

        string Author { get; }

        DateTime Date { get; }
    }
}