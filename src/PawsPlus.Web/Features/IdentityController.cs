using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawsPlus.Application.Identity.Commands.ChangePassword;
using PawsPlus.Application.Identity.Commands.ConfirmEmail;
using PawsPlus.Application.Identity.Commands.CreateUser;
using PawsPlus.Application.Identity.Commands.LoginUser;

namespace PawsPlus.Web.Features;

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

    // [HttpPut]
    // [Authorize]
    // [Route(nameof(ChangeEmail))]
    // public async Task<ActionResult> ChangeEmail(ChangeEmailCommand command)
    //     => await this.Send(command);

    [HttpPut]
    [Authorize]
    [Route(nameof(ChangePassword))]
    public async Task<ActionResult> ChangePassword(ChangePasswordCommand command)
        => await this.Send(command);
}