using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawsPlus.Application.Features.Post.Commands.Activate;
using PawsPlus.Application.Features.Post.Commands.Approve;
using PawsPlus.Application.Features.Post.Commands.Create;
using PawsPlus.Application.Features.Post.Commands.Delete;
using PawsPlus.Application.Features.Post.Commands.Disapprove;
using PawsPlus.Application.Features.Post.Commands.Edit;
using PawsPlus.Application.Features.Post.Queries;
using PawsPlus.Application.Features.Post.Queries.Pending;
using PawsPlus.Application.Features.Post.Queries.Search;

namespace PawsPlus.Web.Features;

public class PostsController : ApiController
{
    [HttpGet]
    [Authorize(Roles = Sitter)]
    [Route(Id)]
    public async Task<ActionResult<PostDetailsOutputModel>> Get(
        [FromRoute] GetPostDetailsQuery query)
        => await this.Send(query);
    
    [HttpPost]
    [Authorize(Roles = Sitter)]
    public async Task<ActionResult> Create(CreatePostCommand command)
        => await this.Send(command);

    [HttpGet]
    [AllowAnonymous]
    [Route(nameof(Search))]
    public async Task<ActionResult<SearchPostsOutputModel>> Search(
        [FromQuery] SearchPostsQuery query)
        => await this.Send(query);
    
    [HttpPut]
    [Authorize(Roles = Sitter)]
    [Route(Id)]
    public async Task<ActionResult> EditPet(EditPostPetCommand command)
        => await this.Send(command);
    
    [HttpDelete]
    [Authorize(Roles = Sitter)]
    [Route(Id)]
    public async Task<ActionResult> DeletePet(DeletePostPetCommand command)
        => await this.Send(command);

    [HttpGet]
    [Authorize(Roles = Administrator)]
    [Route(nameof(Pending))]
    public async Task<ActionResult<ICollection<PendingPostOutputModel>>> Pending(
        [FromRoute] GetPendingPostsQuery query)
        => await this.Send(query);
    
    [HttpPatch]
    [Route("ProfileId" + PathSeparator + nameof(Activate))]
    public async Task<ActionResult> Activate(
        [FromRoute] ActivatePostCommand command)
        => await this.Send(command);
    
    [HttpPatch]
    [Authorize(Roles = Administrator)]
    [Route(Id + PathSeparator + nameof(Approve))]
    public async Task<ActionResult> Approve(
        [FromRoute] ApprovePostCommand command)
        => await this.Send(command);

    [HttpPatch]
    [Authorize(Roles = Administrator)]
    [Route(Id + PathSeparator + nameof(Disapprove))]
    public async Task<ActionResult> Disapprove(DisapprovePostCommand command)
        => await this.Send(command);

}