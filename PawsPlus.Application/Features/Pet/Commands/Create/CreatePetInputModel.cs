using PawsPlus.Application.Features.Pet.Commands.Common;

namespace PawsPlus.Application.Features.Pet.Commands.Create;

public class CreatePetInputModel : BasePetInputModel<CreatePetCommand>
{
    public string ProfileId { get; set; } = default!;
}