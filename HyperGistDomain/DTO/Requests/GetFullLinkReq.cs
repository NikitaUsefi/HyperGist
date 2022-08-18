using System;
using System.Collections.Generic;
using System.Text;

namespace HyperGistDomain.DTO.Requests
{
    public class GetFullLinkReq
    {
        public GetFullLinkReq(string shortLink)
        {
            ShortLink = shortLink;
        }

        public string ShortLink { get; }
    }
}
