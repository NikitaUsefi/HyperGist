using System;
using System.Collections.Generic;
using System.Text;

namespace HyperGistDomain.DTO.Requests
{
    public class GetShortLinkReq
    {
        public GetShortLinkReq(string fullLink)
        {
            FullLink = fullLink;
        }

        public string FullLink { get; }
    }
}
