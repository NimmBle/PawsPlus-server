using Microsoft.AspNetCore.Mvc;
using Zoolandia.Application.Features.Pet.Commands.Create;
using Zoolandia.Application.Features.Pet.Commands.Delete;
using Zoolandia.Application.Features.Pet.Commands.Edit;

namespace Zoolandia.Web.Features;

public class PetsController : ApiController
{

    [HttpPost]
    public async Task<ActionResult<CreatePetOutputModel>> Create(CreatePetCommand command)
        => await this.Send(command);

    [HttpPut]
    [Route(Id)]
    public async Task<ActionResult> Edit(EditPetCommand command)
        => await this.Send(command);

    [HttpDelete]
    [Route(Id)]
    public async Task<ActionResult> Delete(
        [FromRoute] DeletePetCommand command)
        => await this.Send(command);
}