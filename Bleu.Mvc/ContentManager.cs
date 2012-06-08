using System;

namespace Bleu.Mvc
{
    public sealed class ContentManager
    {
        private static IContentSource _source;

        public static IContentSource ContentSource
        {
            get
            {
                return _source;
            }
        }

        public static void SetContentSource(IContentSource source)
        {
            if(source == null)
                throw new ArgumentNullException("source");
            _source = source;
        }
    }
}
