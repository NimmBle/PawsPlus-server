using FluentValidation;
using static PawsPlus.Domain.Models.ModelConstants.Common;

namespace PawsPlus.Application.Features.Pet.Commands.Create;

public class CreatePetCommandValidation : AbstractValidator<CreatePetCommand>
{
    public CreatePetCommandValidation()
    {
        RuleFor(p => p.Name)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();
        
        RuleFor(p => p.PhotoUrl)
            .MaximumLength(MaxUrlLength)
            .NotEmpty();
        
        RuleFor(p => p.Gender).IsInEnum();
    }
}