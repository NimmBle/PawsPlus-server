using FluentValidation;
using static PawsPlus.Domain.Models.ModelConstants.Common;


namespace PawsPlus.Application.Features.Pet.Commands.Edit;

public class EditPetCommandValidation : AbstractValidator<EditPetCommand>
{
    public EditPetCommandValidation()
    {
        RuleFor(p => p.Name)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();
        
        RuleFor(p => p.PhotoUrl)
            .MaximumLength(MaxUrlLength)
            .NotEmpty();
        
        RuleFor(p => p.PetType).IsInEnum();
        
        RuleFor(p => p.Gender).IsInEnum();
    }
}