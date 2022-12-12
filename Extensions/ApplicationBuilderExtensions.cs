using System.Globalization;

namespace WEB_053502_Selhanovich.Extensions
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        //private  ILoggerFactory _loggerFactory;

        public LoggerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger("BadRequest");
            if (context.Response.StatusCode != 200)
            { 
                logger.LogInformation($"Request {context.Request.Path}{context.Request.QueryString} returns status code {context.Response.StatusCode}");
            }

            // Call the next delegate/middleware in the pipeline.
            await _next(context);
        }
    }


    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseLoggin(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LoggerMiddleware>();
        }
    }
}
