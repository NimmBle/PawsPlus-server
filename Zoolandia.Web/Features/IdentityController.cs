using Microsoft.AspNetCore.Mvc;
using Zoolandia.Application.Identity.Commands;
using Zoolandia.Application.Identity.Commands.CreateUser;
using Zoolandia.Application.Identity.Commands.LoginUser;

namespace Zoolandia.Web.Features;

public class IdentityController : ApiController
{

    [HttpPost]
    [Route(nameof(Register))]
    public async Task<ActionResult> Register(CreateUserCommand command)
        => await this.Send(command);

    [HttpPost]
    [Route(nameof(Login))]
    public async Task<ActionResult<LoginOutputModel>> Login(LoginUserCommand command)
        => await this.Send(command);
}