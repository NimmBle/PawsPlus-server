using FluentValidation;

namespace PawsPlus.Application.Features.Pet.Commands.Create;

public class CreatePetCommandValidation : AbstractValidator<CreatePetCommand>
{
    public CreatePetCommandValidation()
    {
        RuleFor(p => p.PetType).IsInEnum();
        
        RuleFor(p => p.Gender).IsInEnum();
    }
}