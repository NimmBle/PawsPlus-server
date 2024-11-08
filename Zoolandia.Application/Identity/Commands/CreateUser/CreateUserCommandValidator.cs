using FluentValidation;

namespace Zoolandia.Application.Identity.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(u => u.Email)
            .EmailAddress()
            .NotEmpty();
    }
}