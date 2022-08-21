using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BookStoreWebApi.Common.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                string message = httpContext.Request.Method + " " + httpContext.Request.Path;
                Console.WriteLine(message);
                await _next(httpContext);

                message = httpContext.Response.StatusCode + " Ok ";
                Console.WriteLine(message);
            }
            catch (Exception ex)
            {
                await HandleExcepiton(httpContext, ex);
            }
        }

        public async Task HandleExcepiton(HttpContext httpContext, Exception ex)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message = httpContext.Request.Method + " " + httpContext.Response.StatusCode + " " + ex.Message;

            Console.WriteLine(message);
            var result = JsonConvert.SerializeObject(new { error = ex.Message }, Formatting.Indented);
            await httpContext.Response.WriteAsync(result);
        }
    }

    static public class CustomExceptionMiddlewareExtension
    {
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionMiddleware>();
        }
    }
}
