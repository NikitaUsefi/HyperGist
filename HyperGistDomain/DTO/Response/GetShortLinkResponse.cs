using System;
using System.Collections.Generic;
using System.Text;

namespace HyperGistDomain.DTO.Response
{
    public class GetShortLinkResponse:BaseResponse
    {
        public string ShortLink { get; set; }
        public GetShortLinkResponse(bool isSuccessful, string message) : this(null,isSuccessful, message)
        {
        }
        public GetShortLinkResponse(string shortLink,bool isSuccessful, string message):base(isSuccessful,message)
        {
            ShortLink = shortLink;
        }

    }
}
