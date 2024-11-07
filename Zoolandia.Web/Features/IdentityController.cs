using Microsoft.AspNetCore.Mvc;
using Zoolandia.Applicaiton.Identity.Commands.CreateUser;
using Zoolandia.Applicaiton.Identity.Commands.LoginUser;

namespace Zoolandia.Web.Features;

public class IdentityController : ApiController
{

    [HttpPost]
    [Route(nameof(Register))]
    public async Task<ActionResult> Register(CreateUserCommand command)
        => await this.Send(command);

    [HttpPost]
    [Route(nameof(Login))]
    public async Task<ActionResult> Login(LoginUserCommand command)
        => await this.Send(command);
}