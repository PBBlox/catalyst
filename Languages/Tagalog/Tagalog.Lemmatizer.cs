
using System;
using System.Collections.Generic;
using Catalyst;
using Mosaik.Core;

namespace Catalyst.Models
{
    public static partial class Tagalog
    {
        internal sealed class Lemmatizer : ILemmatizer
        {
            public Language Language => Language.Tagalog;

            private static Lazy<Lookups> _lookup = new Lazy<Lookups>(() => Lookups.FromStream(ResourceLoader.OpenResource(typeof(Lemmatizer).Assembly, "tl_lemma_lookup.bin")).WaitResult(), isThreadSafe:true);

            public string GetLemma(IToken token) => new string(GetLemmaAsSpan(token));

            public ReadOnlySpan<char> GetLemmaAsSpan(IToken token) => _lookup.Value.Get(token);

            public bool IsBaseForm(IToken token)
            {
                return false;
            }
        }
    }
}
