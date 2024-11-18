using FluentValidation;
using static Zoolandia.Domain.Models.ModelConstants.Common;

namespace Zoolandia.Application.Identity.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(u => u.FirstName)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();
        
        RuleFor(u => u.LastName)
            .MinimumLength(MinNameLength)
            .MaximumLength(MaxNameLength)
            .NotEmpty();

        RuleFor(u => u.Password)
            .MaximumLength(MaxNameLength);
        
        RuleFor(u => u.Email)
            .EmailAddress()
            .MinimumLength(MinEmailLength)
            .MaximumLength(MaxEmailLength)
            .NotEmpty();
    }
}