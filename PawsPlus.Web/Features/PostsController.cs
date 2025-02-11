using Microsoft.AspNetCore.Mvc;
using PawsPlus.Application.Features.Post.Commands.Create;
using PawsPlus.Application.Features.Post.Commands.Delete;
using PawsPlus.Application.Features.Post.Commands.Edit;
using PawsPlus.Application.Features.Post.Queries;
using PawsPlus.Application.Features.Post.Queries.Search;

namespace PawsPlus.Web.Features;

public class PostsController : ApiController
{
    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<PostDetailsOutputModel>> Get(
        [FromRoute] GetPostDetailsQuery query)
        => await this.Send(query);
    
    [HttpPost]
    public async Task<ActionResult> Create(CreatePostCommand command)
        => await this.Send(command);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult> EditPet(EditPostPetCommand command)
        => await this.Send(command);

    [HttpGet]
    [Route(nameof(Search))]
    public async Task<ActionResult<SearchPostsOutputModel>> Search(
        [FromQuery] SearchPostsQuery query)
        => await this.Send(query);
    
    [HttpDelete]
    [Route(Id)]
    public async Task<ActionResult> DeletePet(DeletePostPetCommand command)
        => await this.Send(command);
}