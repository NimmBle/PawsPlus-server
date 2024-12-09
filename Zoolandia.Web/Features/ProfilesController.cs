using Microsoft.AspNetCore.Mvc;
using Zoolandia.Application.Features.Profile.Commands;
using Zoolandia.Application.Features.Profile.Queries;

namespace Zoolandia.Web.Features;

public class ProfilesController : ApiController
{
    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<ProfileDetailsOutputModel>> Details(
        [FromRoute] ProfileDetailsQuery query)
        => await this.Send(query);
    
    [HttpGet]
    public async Task<ActionResult<ProfileDetailsOutputModel>> Myself(
        [FromQuery] ProfileDetailsQuery query)
        => await this.Send(query);
    
    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult> Edit(EditProfileCommand command)
        => await this.Send(command);
}