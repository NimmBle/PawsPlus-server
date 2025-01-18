using Microsoft.AspNetCore.Mvc;
using Zoolandia.Application.Features.Service.Commands.Create;
using Zoolandia.Application.Features.Service.Commands.Edit;

namespace Zoolandia.Web.Features;

public class ServicesController : ApiController
{
    
    [HttpPost]
    public async Task<ActionResult<string>> CreateService(CreateServiceCommand command)
        => await this.Send(command);
    
    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult> EditService(EditServiceCommand command)
        => await this.Send(command);
}