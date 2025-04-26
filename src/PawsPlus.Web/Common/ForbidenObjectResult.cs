using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PawsPlus.Web.Common;

public class ForbidenObjectResult : ObjectResult
{
    private const int DefaultStatusCode = StatusCodes.Status403Forbidden;
    
    public ForbidenObjectResult(object? value) 
        : base(value)
    {
        StatusCode = DefaultStatusCode;
    }
}