using Microsoft.AspNetCore.Mvc;
using Zoolandia.Applicaiton.Identity.Commands;

namespace Zoolandia.Web.Features;

public class IdentityController : ApiController
{

    [HttpPost]
    [Route(nameof(Register))]
    public async Task<ActionResult> Register(CreateUserCommand command)
        => await this.Send(command);
    
}