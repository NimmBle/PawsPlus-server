using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Zoolandia.Application.Common;
using Zoolandia.Web.Common;

namespace Zoolandia.Web;

[ApiController]
[Route("[controller]")]
[Authorize]
public class ApiController : ControllerBase
{
    public const string Id = "{Id}";
    public const string PathSeparator = "/";
    public const string Administrator = "Administrator";
    
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