using FluentValidation;

namespace PawsPlus.Application.Features.Post.Commands.Create;

public class CreatePostCommandValidation : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidation()
    {

    }
}