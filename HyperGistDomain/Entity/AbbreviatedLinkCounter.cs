using HyperGistDomain.Entity;
using System;

namespace HyperGistDomain
{
    public class AbbreviatedLinkCounter: BaseEntity
    {
        public AbbreviatedLinkCounter()
        {

        }
        public AbbreviatedLinkCounter(string prefix, string lastCount)
        {
            Prefix = prefix;
            LastCount = lastCount;
        }

        public string Prefix { get; set; }
        public string LastCount { get; set; }
    }
}
