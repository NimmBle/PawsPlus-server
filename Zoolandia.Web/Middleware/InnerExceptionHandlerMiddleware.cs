using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Zoolandia.Web.Middleware;

public class InnerExceptionHandlerMiddleware (RequestDelegate next,
    ILogger<InnerExceptionHandlerMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex)
        {
            LogExceptionDetails(ex);
            
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync("An unexpected error occurred.");
        }
    }

    private void LogExceptionDetails(Exception ex)
    {
        logger.LogError(ex, "An unhandled exception occurred.");
    }
}

public static class CustomExceptionHandlerMiddlewareExtensions
{
    public static IApplicationBuilder UseInnerExceptionHandler(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<InnerExceptionHandlerMiddleware>();
    }
}