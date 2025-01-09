using Zoolandia.Application.Features.Pet.Commands.Common;

namespace Zoolandia.Application.Features.Pet.Commands.Create;

public class CreatePetInputModel : PetCommand<CreatePetCommand>
{
    public string ProfileId { get; set; } = default!;
}