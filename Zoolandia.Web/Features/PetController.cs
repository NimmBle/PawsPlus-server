using Microsoft.AspNetCore.Mvc;
using Zoolandia.Application.Features.Pet.Commands.CreatePet;

namespace Zoolandia.Web.Features;

public class PetController : ApiController
{

    [HttpPost]
    public async Task<ActionResult> Create(CreatePetCommand command)
        => await this.Send(command);

}