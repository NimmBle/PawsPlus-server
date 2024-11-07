using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Zoolandia.Application.Common;
using Zoolandia.Web.Common;

namespace Zoolandia.Web;

[ApiController]
[Route("[controller]")]
public class ApiController : ControllerBase
{
    private IMediator? mediator;
    protected IMediator Mediator
        => this.mediator ??= this.HttpContext
            .RequestServices
            .GetService<IMediator>();

    protected Task<ActionResult> Send(IRequest<Result> request)
        => Mediator.Send(request).ToActionResult();
}