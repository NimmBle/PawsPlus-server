using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawsPlus.Application.Features.Post.Queries;
using PawsPlus.Application.Features.Profile.Commands.Edit;
using PawsPlus.Application.Features.Profile.Queries.Mine;
using PawsPlus.Application.Features.Profile.Queries.MinePet;
using PawsPlus.Application.Features.Profile.Queries.Details;

namespace PawsPlus.Web.Features;

public class ProfilesController : ApiController
{
    [HttpGet]
    [Route(nameof(Mine))]
    public async Task<ActionResult<MineProfileOutputModel>> Mine(
        [FromQuery] MineProfileQuery query)
        => await this.Send(query);

    [HttpGet]
    [Authorize(Roles = $"{Owner}, {Sitter}")]
    [Route(Id + PathSeparator + nameof(MyPet))]
    public async Task<ActionResult<PetOutputModel>> MyPet(
        [FromRoute] GetProfilePetQuery query)
        => await this.Send(query);

    [HttpGet]
    [Authorize(Roles = Sitter)]
    [Route(Id + PathSeparator + nameof(MyPost))]
    public async Task<ActionResult<PostDetailsOutputModel>> MyPost(
        [FromRoute] GetProfilePostDetailsQuery query)
        => await this.Send(query);

    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<ProfileDetailsOutputModel>> Details(
        [FromRoute] GetProfileDetailsQuery query)
        => await this.Send(query);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult> Edit(EditProfileCommand command)
        => await this.Send(command);
}