using PawsPlus.Domain.Common;

namespace PawsPlus.Application.Identity;

public class IdentityErrors
{
    public static Error UserNotFound(string id) => Error.NotFound(
        "Identity.UserNotFound", $"No user found with the given id: '{id}'"); 
    
    public static Error InvalidCredentials => Error.Validation(
        "Identity.InvalidCredentials", $"The credentials are invalid. Please try again"); 
    
    public static Error EmailNotUnique => Error.Conflict(
        "Identity.EmailNotUnique", $"The email address is already used"); 
    
    public static Error EmailAlreadyConfirmed(string email) => Error.Conflict(
        "Identity.EmailAlreadyConfirmed", $"This email address has already been confirmed: '{email}'"); 
    
    public static Error EmailConfirmationFailed(string email) => Error.Failure(
        "Identity.EmailConfirmationFailed", $"This email could not be confirmed: '{email}'. Please try again");
    
    public static Error EmailChangeFailed => Error.Failure(
        "Identity.EmailChangeFailed", $"You cannot change your email at this moment. Please try again");
    
    public static Error UserCreationFailed => Error.Failure(
        "Identity.UserCreationFailed", $"We could not create you an account as of this moment. Please try again");
    
    public static Error UserRolesFailed => Error.Failure(
        "Identity.UserRolesFailed", $"We could asign you the correct roles. Please try again");
    
}