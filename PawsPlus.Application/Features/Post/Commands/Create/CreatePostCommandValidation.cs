using FluentValidation;
using PawsPlus.Domain.Enums;
using PawsPlus.Domain.Enums.Pet;

namespace PawsPlus.Application.Features.Post.Commands.Create;

public class CreatePostCommandValidation : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidation()
    {

    }
}