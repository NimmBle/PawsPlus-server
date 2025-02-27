using FluentValidation;
using PawsPlus.Domain.Enums;
using PawsPlus.Domain.Enums.Pet;

namespace PawsPlus.Application.Features.Post.Commands.Create;

public class CreatePostCommandValidation : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidation()
    {
        RuleFor(p => p.Services)
            .NotNull()
            .Must(serviceTypes => serviceTypes.All(p => Enum.IsDefined(typeof(ServiceType), p)))
            .WithMessage("All service types must be valid members of the ServiceType enum.");
        
        // RuleFor(p => p.Pets)
        //     .NotNull()
        //     .Must(petTypes => petTypes.All(p => Enum.IsDefined(typeof(PetType), p)))
        //     .WithMessage("All pet types must be valid members of the PetType enum.");
    }
}