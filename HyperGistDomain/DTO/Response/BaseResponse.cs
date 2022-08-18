using System;
using System.Collections.Generic;
using System.Text;

namespace HyperGistDomain.DTO.Response
{
    public class BaseResponse
    {
        public BaseResponse()
        {

        }
        public BaseResponse(bool isSuccessful, string message)
        {
            IsSuccessful = isSuccessful;
            Message = message;
        }

        public bool IsSuccessful { get; set; }
        public string Message { get; set; }

    }
}
