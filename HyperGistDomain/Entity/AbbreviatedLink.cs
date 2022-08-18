using HyperGistDomain.Entity;
using System;

namespace HyperGistDomain
{
    public class AbbreviatedLink: BaseEntity
    {
        public AbbreviatedLink()
        {

        }
        public AbbreviatedLink(string prefix,string counter, string fullLink):this()
        {
            Prefix = prefix;
            ShortLink = $"{prefix}/{counter}";
            FullLink = fullLink;
        }

        public string Prefix { get; set; }
        public string ShortLink { get; set; }
        public string FullLink { get; set; }
    }
}
