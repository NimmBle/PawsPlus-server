using FluentValidation;
using PawsPlus.Domain.Enums.Pet;

namespace PawsPlus.Application.Features.Post.Commands.Edit;

public class EditPostCommandValidation : AbstractValidator<EditPostPetCommand>
{
    public EditPostCommandValidation()
    {
        RuleFor(e => e.Weights)
            .Must(weights => weights.All(w => Enum.IsDefined(typeof(Weight), w)))
            .WithMessage("All weights must be valid members of the Weights enum.");
    }
}