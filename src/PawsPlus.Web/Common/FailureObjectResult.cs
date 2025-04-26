using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PawsPlus.Web.Common;

public class FailureObjectResult : ObjectResult
{
    private const int DefaultStatusCode = StatusCodes.Status500InternalServerError;
    
    public FailureObjectResult(object? value) 
        : base(value)
    {
        StatusCode = DefaultStatusCode;
    }
}