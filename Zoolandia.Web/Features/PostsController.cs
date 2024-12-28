using Microsoft.AspNetCore.Mvc;
using Zoolandia.Application.Features.Post.Commands.Create;
using Zoolandia.Application.Features.Post.Queries;

namespace Zoolandia.Web.Features;

public class PostsController : ApiController
{
    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<PostDetailsOutputModel>> Get(PostDetailsQuery query)
        => await this.Send(query);
    
    [HttpPost]
    public async Task<ActionResult> Create(CreatePostCommand command)
        => await this.Send(command);
}