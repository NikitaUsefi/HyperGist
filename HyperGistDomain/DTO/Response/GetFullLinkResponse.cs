using System;
using System.Collections.Generic;
using System.Text;

namespace HyperGistDomain.DTO.Response
{
    public class GetFullLinkResponse : BaseResponse
    {
        public string FullLink { get; set; }
        public GetFullLinkResponse(bool isSuccessful, string message) : this(null, isSuccessful, message)
        {
        }
        public GetFullLinkResponse(string fullLink,bool isSuccessful, string message):base(isSuccessful,message)
        {
            FullLink = fullLink;
        }
       

    }
}
