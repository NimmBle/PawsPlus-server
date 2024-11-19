using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zoolandia.Application.Features.Profile.Commands;

namespace Zoolandia.Web.Features;

[Authorize]
public class ProfilesController : ApiController
{
    [HttpPut]
    [Route(nameof(Edit) + Separator + Id)]
    public async Task<ActionResult> Edit(EditProfileCommand command)
        => await this.Send(command);
}