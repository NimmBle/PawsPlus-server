using PawsPlus.Domain.Common;

namespace PawsPlus.Application.Identity;

public class IdentityErrors
{
    // General errors
    public static Error IdentityError(string description) => Error.Validation(
        "Identity.IdentityError", description);

    public static Error UserNotFound(string id) => Error.NotFound(
        "Identity.UserNotFound", $"Не е намерен потребител с даденото ID: '{id}'");

    public static Error InvalidCredentials => Error.Validation(
        "Identity.InvalidCredentials", $"Невалидни идентификационни данни. Моля, опитайте отново");

// Email errors
    public static Error EmailNotUnique => Error.Conflict(
        "Identity.EmailNotUnique", $"Имейл адресът вече е използван");

    public static Error EmailNotConfirmed => Error.Validation(
        "Identity.EmailNotConfirmed", $"Имейл адресът не е потвърден");

    public static Error EmailAlreadyConfirmed(string email) => Error.Conflict(
        "Identity.EmailAlreadyConfirmed", $"Този имейл адрес вече е потвърден: '{email}'");

    public static Error EmailConfirmationFailed(string email) => Error.Failure(
        "Identity.EmailConfirmationFailed", $"Този имейл не можа да бъде потвърден: '{email}'. Моля, опитайте отново");

    public static Error EmailChangeFailed => Error.Failure(
        "Identity.EmailChangeFailed", $"В момента не можете да промените имейла си. Моля, опитайте отново");
    
    
    public static Error PasswordChangeFailed => Error.Failure(
        "Identity.PasswordChangeFailed", "We could not change your password. Please try again");
}