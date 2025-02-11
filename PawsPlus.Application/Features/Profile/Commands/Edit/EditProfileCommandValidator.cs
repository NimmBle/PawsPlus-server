using FluentValidation;
using static PawsPlus.Domain.Models.ModelConstants.Common;
using static PawsPlus.Domain.Models.ModelConstants.Profile;

namespace PawsPlus.Application.Features.Profile.Commands.Edit;

public class EditProfileCommandValidator : AbstractValidator<EditProfileCommand>
{
    public EditProfileCommandValidator()
    {
        RuleFor(p => p.FirstName)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();
        
        RuleFor(p => p.LastName)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();

        RuleFor(p => p.Description)
            .MaximumLength(MaxDescriptionLength);
        
        // finish it all the way
    }
}