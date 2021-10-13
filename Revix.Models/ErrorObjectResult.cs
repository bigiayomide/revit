using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
namespace Revix.Models
{
    public class ErrorObjectResult : ObjectResult
    {
        public ErrorObjectResult(ErrorViewModel model, HttpStatusCode code)
            : base(model)
        {
            StatusCode = (int?)code;
        }
    }

    public class ErrorViewModel
    {
        public object Error { get; set; }
        public ErrorViewModel(object error)
        {
            Error = error;
        }
    }

    public class GlobalException : Exception
    {
        public GlobalException(string message, object result = null, HttpStatusCode code = HttpStatusCode.BadRequest)
            : base(message)
        {
            this.Data.Add("CustomStatusCode", (int)code);
            this.Data.Add("HttpResponseObject", result);
        }
    }
}