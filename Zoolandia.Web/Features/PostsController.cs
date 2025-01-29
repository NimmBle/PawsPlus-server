using Microsoft.AspNetCore.Mvc;
using Zoolandia.Application.Features.Post.Commands.Create;
using Zoolandia.Application.Features.Post.Commands.Delete;
using Zoolandia.Application.Features.Post.Commands.Edit;
using Zoolandia.Application.Features.Post.Queries;
using Zoolandia.Application.Features.Post.Queries.Search;

namespace Zoolandia.Web.Features;

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