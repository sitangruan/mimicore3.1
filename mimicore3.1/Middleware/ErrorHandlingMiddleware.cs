using Microsoft.AspNetCore.Http;
using mimicore3._1.CustomException;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace mimicore3._1.Middleware
{
    internal class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exp)
        {
            var hexp = exp as HttpResponseException;
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = hexp.StatusCode;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(hexp, Formatting.Indented));
        }
    }
}
