using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mimicore3._1.CustomException
{
    public class HttpResponseException : Exception
    {
        public int StatusCode { get; set; } = 500;

        public string ErrorMessage { get; set; }

        public HttpResponseException(int statusCode, string errorMsg)
        {
            StatusCode = statusCode;
            ErrorMessage = errorMsg;
        }
    }
}
