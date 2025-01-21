using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zoolandia.Application.Features.Pet.Queries;
using Zoolandia.Application.Features.Post.Queries;
using Zoolandia.Application.Features.Profile.Commands.Edit;
using Zoolandia.Application.Features.Profile.Queries;

namespace Zoolandia.Web.Features;

public class ProfilesController : ApiController
{
    [HttpGet]
    public async Task<ActionResult<ProfileDetailsOutputModel>> Myself(
        [FromQuery] ProfileDetailsQuery query)
        => await this.Send(query);
    
    [HttpGet]
    [Route(Id + PathSeparator + nameof(MyPet))]
    public async Task<ActionResult<PetOutputModel>> MyPet(
        [FromRoute] GetProfilePetQuery query)
        => await this.Send(query);  
    
    [HttpGet]
    [Route(Id + PathSeparator + nameof(MyPost))]
    public async Task<ActionResult<PostDetailsOutputModel>> MyPost(
        [FromRoute] GetProfilePostDetailsQuery query)
        => await this.Send(query);
        
    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<ProfileDetailsOutputModel>> Details(
        [FromRoute] ProfileDetailsQuery query)
        => await this.Send(query);

    [HttpGet]
    [Authorize(Roles = Administrator)]
    [Route(nameof(MyPets))]
    public async Task<string> MyPets()
        => "banans";
    
    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult> Edit(EditProfileCommand command)
        => await this.Send(command);
}