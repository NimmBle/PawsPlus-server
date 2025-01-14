using Microsoft.AspNetCore.Mvc;
using Zoolandia.Application.Features.Post.Commands.Create;
using Zoolandia.Application.Features.Post.Queries;
using Zoolandia.Application.Features.PostService.Commands;

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
    [Route("{postId}/service/{serviceId}")]
    public async Task<ActionResult> EditService(EditPostServiceCommand command)
        => await this.Send(command);
    
    [HttpPost]
    [Route("{Id}/service")]
    public async Task<ActionResult<string>> CreateService(CreatePostServiceCommand command)
        => await this.Send(command);
}