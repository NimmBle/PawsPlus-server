using Microsoft.AspNetCore.Mvc;
using Zoolandia.Application.Features.Pet.Queries;
using Zoolandia.Application.Features.Post.Queries;
using Zoolandia.Application.Features.Profile.Commands;
using Zoolandia.Application.Features.Profile.Queries;

namespace Zoolandia.Web.Features;

public class ProfilesController : ApiController
{
    [HttpGet]
    public async Task<ActionResult<ProfileDetailsOutputModel>> Myself(
        [FromQuery] ProfileDetailsQuery query)
        => await this.Send(query);
    
    [HttpGet]
    [Route(Id + "/pet")]
    public async Task<ActionResult<PetOutputModel>> MyPet(
        [FromRoute] GetProfilePetQuery query)
        => await this.Send(query);
    
    [HttpGet]
    [Route(Id + "/post")]
    public async Task<ActionResult<PostDetailsOutputModel>> MyPost(
        [FromRoute] GetProfilePostDetailsQuery query)
        => await this.Send(query);
        
    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<ProfileDetailsOutputModel>> Details(
        [FromRoute] ProfileDetailsQuery query)
        => await this.Send(query);
    
    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult> Edit(EditProfileCommand command)
        => await this.Send(command);
}