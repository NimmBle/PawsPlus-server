using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawsPlus.Application.Features.Service.Commands.Create;
using PawsPlus.Application.Features.Service.Commands.Delete;
using PawsPlus.Application.Features.Service.Commands.Edit;
using PawsPlus.Application.Features.Service.Queries;

namespace PawsPlus.Web.Features;

[Authorize(Roles = Sitter)]
public class ServicesController : ApiController
{
    
    [HttpGet]
    [Route(Id)]
    public async Task<ActionResult<ServiceOutputModel>> Get(
        [FromRoute] GetServiceQuery query)
        => await this.Send(query);
    
    [HttpPost]
    public async Task<ActionResult> Create(CreateServiceCommand command)
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