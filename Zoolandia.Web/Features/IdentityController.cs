using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zoolandia.Application.Identity.Commands;
using Zoolandia.Application.Identity.Commands.ChangeEmail;
using Zoolandia.Application.Identity.Commands.ConfirmEmail;
using Zoolandia.Application.Identity.Commands.CreateUser;
using Zoolandia.Application.Identity.Commands.LoginUser;

namespace Zoolandia.Web.Features;

[AllowAnonymous]
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

    [HttpPut]
    [Route(nameof(ConfirmEmail))]
    public async Task<ActionResult> ConfirmEmail(ConfirmEmailCommand command)
        => await this.Send(command);

    [HttpPut]
    [Authorize]
    [Route(nameof(ChangeEmail))]
    public async Task<ActionResult> ChangeEmail(ChangeEmailCommand command)
        => await this.Send(command);
}