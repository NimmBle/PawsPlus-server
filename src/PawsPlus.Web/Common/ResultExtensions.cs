using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Common;

namespace PawsPlus.Web.Common;

public static class ResultExtensions
{
    
    public static async Task<ActionResult> ToActionResult(this Task<Result> resultTask)
    {
        var result = await resultTask;
        
        if (!result.Succeeded)
        {
            return result.ToObjectResult();
        }
            
        return new OkResult();
    }
    
    public static async Task<ActionResult<TData>> ToActionResult<TData>(this Task<Result<TData>> resultTask)
    {
        var result = await resultTask;

        if (!result.Succeeded)
        {
            return result.ToObjectResult();
        }
        
        return result.Data;
    }

    private static ObjectResult ToObjectResult(this Result result)
    {
        if (result.Error.Type == ErrorType.Validation)
            return new BadRequestObjectResult(result.ToProblemDetails());
        if (result.Error.Type == ErrorType.NotFound)
            return new NotFoundObjectResult(result.ToProblemDetails());
        if (result.Error.Type == ErrorType.Conflict)
            return new ConflictObjectResult(result.ToProblemDetails());
        if (result.Error.Type == ErrorType.Forbidden)
            return new ForbidenObjectResult(result.ToProblemDetails());
        
        return new FailureObjectResult(result.Error);
    }
    
    // public static async Task<ActionResult<TData>> ToActionResult<TData>(this Task<TData> resultTask)
    // {
    //     var result = await resultTask;
    //
    //     if (result == null)
    //     {
    //         return new NotFoundResult();
    //     }
    //         
    //     return result;
    // }

    public static IResult ToProblemDetails(this Result result)
    {
        if (result.Succeeded)
        {
            throw new InvalidOperationException();
        }
        
        return Results.Problem(
            statusCode: GetStatusCode(result.Error.Type),
            title: GetTitle(result.Error.Type),
            type: GetType(result.Error.Type),
            extensions: new Dictionary<string, object?>
            {
                { "errors", new[] { result.Error }}
            });


        static int GetStatusCode(ErrorType errorType)
            => errorType switch
            {
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                ErrorType.Forbidden => StatusCodes.Status403Forbidden,
                _ => StatusCodes.Status500InternalServerError,
            };
        
        static string GetTitle(ErrorType errorType)
            => errorType switch
            {
                ErrorType.Validation => "Bad Request",
                ErrorType.NotFound => "Not Found",
                ErrorType.Conflict => "Conflict",
                ErrorType.Forbidden => "Forbidden",
                _ => "Server Failure",
            };

        static string GetType(ErrorType errorType)
            => errorType switch
            {
                ErrorType.Validation => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                ErrorType.NotFound => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
                ErrorType.Conflict => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8",
                ErrorType.Forbidden => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.3",
                _ => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1"
            };
    }
}