using FluentValidation;
using static PawsPlus.Domain.Models.ModelConstants.Common;

namespace PawsPlus.Application.Identity.Commands.CreateUser;

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

        RuleFor(u => u.Role)
            .IsInEnum();
    }
}