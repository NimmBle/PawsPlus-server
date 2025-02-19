using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Errors;

public class ProfileErrors
{

    public static Error ProfileNotFound(string id) => Error.NotFound(
        "Profile.ProfileNotFound", $"No profile was found with this id: '{id}'");
    
    public static Error ProfilePostNotFound(string id) => Error.NotFound(
        "Profile.ProfilePostNotFound", $"No post for profile was found with the given profile id: '{id}'");
    
    public static Error ProfileAccessNotAllowed(string id) => Error.Forbidden(
        "Profile.ProfileAccessNotAllowed", $"You are not allowed to access this profile with id: '{id}'");
}