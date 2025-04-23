using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawsPlus.Application.Features.Pet.Commands.Create;
using PawsPlus.Application.Features.Pet.Commands.Delete;
using PawsPlus.Application.Features.Pet.Commands.Edit;
using PawsPlus.Application.Features.Pet.Queries.Details;

namespace PawsPlus.Web.Features;

[Authorize(Roles = Owner)]
public class PetsController : ApiController
{
    [HttpGet]
    [Authorize(Roles = $"{Owner}, {Sitter}")]
    [Route(Id)]
    public async Task<ActionResult<PetDetailsOutputModel>> Get(
        [FromRoute] GetPetDetailsQuery query)
        => await this.Send(query);
    

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