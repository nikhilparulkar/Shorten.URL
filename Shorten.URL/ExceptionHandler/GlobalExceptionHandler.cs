using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Shorten.URL.ExceptionHandler
{
    public class GlobalExceptionHandler
    {
        private readonly RequestDelegate _next;
        //private readonly ILoggerManager _logger;

        //public ExceptionMiddleware(RequestDelegate next, ILoggerManager logger)
        public GlobalExceptionHandler(RequestDelegate next)
        {
            //_logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                //_logger.LogError($"Something went wrong: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {

                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var customMessage = exception.Message;
                return context.Response.WriteAsync((new { status=HttpStatusCode.InternalServerError,Message= "Microservice - Unexpected error" }).ToString());
            


        }
    }
}

