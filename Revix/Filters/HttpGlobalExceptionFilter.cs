using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Revix.Models;
using System;
using System.Net;

namespace Revix.Filters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<HttpGlobalExceptionFilter> _logger;
        public HttpGlobalExceptionFilter(IWebHostEnvironment env, ILogger<HttpGlobalExceptionFilter> logger)
        {
            _env = env;
            _logger = logger;
        }


        public void OnException(ExceptionContext context)
        {
            if (context.Exception is TimeoutException)
            {
                SetExceptionResult(context, context.Exception, HttpStatusCode.RequestTimeout);
            }
            else if (context.Exception is GlobalException)
            {
                int code = (int)context.Exception.Data["CustomStatusCode"];
                object customResult = context.Exception.Data["HttpResponseObject"];

                SetExceptionResult(context, context.Exception, (HttpStatusCode)code, customResult);
            }
            else if (context.Exception is Exception)
            {
                SetExceptionResult(context, context.Exception, HttpStatusCode.BadRequest);
            }
            else
            {
                SetExceptionResult(context, context.Exception, HttpStatusCode.InternalServerError);
            }
        }
        private void SetExceptionResult(ExceptionContext context, System.Exception exception, HttpStatusCode code, object customResult = null)
        {
            _logger.LogError(context.Exception.Message, exception);

            context.HttpContext.Response.Headers.Add("Access-Control-Allow-Credentials", "true");
            context.HttpContext.Response.Headers.Add("Access-Control-Allow-Methods", "POST, GET, OPTIONS, DELETE");

            if (!_env.IsDevelopment() && !(context.Exception is GlobalException))
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Result = new ObjectResult(new ErrorViewModel($"A System Error Occured. Please Contact Admin"));
            }
            else
            {
                if (customResult == null)
                    context.Result = new ObjectResult(new ErrorViewModel(context.Exception.Message));
                else
                    context.Result = new ObjectResult(new ErrorViewModel(customResult));

            }

            context.HttpContext.Response.StatusCode = (int)code;
            context.ExceptionHandled = true;
        }
    }
}