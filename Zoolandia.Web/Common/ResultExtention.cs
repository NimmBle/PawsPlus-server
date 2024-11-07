using Microsoft.AspNetCore.Mvc;
using Zoolandia.Application.Common;

namespace Zoolandia.Web.Common;

public static class ResultExtention
{
    public static async Task<ActionResult> ToActionResult(this Task<Result> resultTask)
    {
        var result = await resultTask;

        if (!result.Succeeded)
            return new BadRequestObjectResult(result.Errors);

        return new OkResult();
    }
}