using FluentValidation;

namespace Zoolandia.Application.Features.Pet.Commands.Create;

public class CreatePetCommandValidation : AbstractValidator<CreatePetCommand>
{
    public CreatePetCommandValidation()
    {
        RuleFor(p => p.Age.Years).GreaterThan(0);
        RuleFor(p => p.Age.Months).GreaterThan(0);
        
        
        RuleFor(p => p.PetType).IsInEnum();
        
        RuleFor(p => p.Gender).IsInEnum();
    }
}