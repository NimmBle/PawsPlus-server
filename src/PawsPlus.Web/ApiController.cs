using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using PawsPlus.Application.Common;
using PawsPlus.Web.Common;

namespace PawsPlus.Web;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ApiController : ControllerBase
{
    public const string Id = "{Id}";
    public const string ProfileId = "{ProfileId}";
    public const string PathSeparator = "/";
    
    public const string Administrator = "Administrator";
    public const string Owner = "Owner";
    public const string Sitter = "Sitter";
    
    private IMediator? mediator;
    protected IMediator Mediator
        => mediator ??= HttpContext
            .RequestServices
            .GetService<IMediator>();

    protected Task<ActionResult<TResult>> Send<TResult>(IRequest<TResult> request)
        => Mediator.Send(request).ToActionResult();
    
    protected Task<ActionResult> Send(IRequest<Result> request)
        => Mediator.Send(request).ToActionResult();

    protected Task<ActionResult<TResult>> Send<TResult>(IRequest<Result<TResult>> request)
        => Mediator.Send(request).ToActionResult();
}