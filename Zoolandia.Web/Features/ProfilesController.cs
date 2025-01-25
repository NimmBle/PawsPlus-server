using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zoolandia.Application.Features.Pet.Queries;
using Zoolandia.Application.Features.Post.Queries;
using Zoolandia.Application.Features.Profile.Commands.Edit;
using Zoolandia.Application.Features.Profile.Queries.Mine;
using Zoolandia.Application.Features.Profile.Queries.Search;

namespace Zoolandia.Web.Features;

public class ProfilesController : ApiController
{
    [HttpGet]
    [Route(nameof(Mine))]
    public async Task<ActionResult<MineProfileOutputModel>> Mine(
        [FromQuery] MineProfileQuery query)
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
        [FromRoute] GetProfileDetailsQuery query)
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