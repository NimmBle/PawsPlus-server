using Microsoft.AspNetCore.Mvc;
using PawsPlus.Application.Features.Pet.Commands.Create;
using PawsPlus.Application.Features.Pet.Commands.Delete;
using PawsPlus.Application.Features.Pet.Commands.Edit;

namespace PawsPlus.Web.Features;

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