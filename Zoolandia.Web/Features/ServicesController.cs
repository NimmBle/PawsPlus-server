using Microsoft.AspNetCore.Mvc;
using Zoolandia.Application.Features.Service;
using Zoolandia.Application.Features.Service.Commands.Create;
using Zoolandia.Application.Features.Service.Commands.Delete;
using Zoolandia.Application.Features.Service.Commands.Edit;
using Zoolandia.Application.Features.Service.Queries;

namespace Zoolandia.Web.Features;

public class ServicesController : ApiController
{
    
    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<ServiceOutputModel>> Get(
        [FromRoute] GetServiceQuery query)
        => await this.Send(query);
    
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