using FluentValidation;
using static Zoolandia.Domain.Models.ModelConstants.Common;
using static Zoolandia.Domain.Models.ModelConstants.Profile;

namespace Zoolandia.Application.Features.Profile.Commands.Edit;

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