using Microsoft.AspNetCore.Mvc;
using Zoolandia.Application.Features.Service.Commands.Create;
using Zoolandia.Application.Features.Service.Commands.Delete;
using Zoolandia.Application.Features.Service.Commands.Edit;

namespace Zoolandia.Web.Features;

public class ServicesController : ApiController
{
    
    [HttpPost]
    public async Task<ActionResult<string>> Create(CreateServiceCommand command)
        => await this.Send(command);
    
    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult> Edit(EditServiceCommand command)
        => await this.Send(command);

    [HttpDelete]
    [Route(Id)]
    public async Task<ActionResult> Delete(
        [FromRoute] DeleteServiceCommand command)
        => await this.Send(command);
}