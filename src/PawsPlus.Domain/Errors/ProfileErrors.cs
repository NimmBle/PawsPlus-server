using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Errors;

public class ProfileErrors
{
    public static Error ProfileNotFound(string id) => Error.NotFound(
        "Profile.ProfileNotFound", $"Няма намерен профил с този идентификатор: '{id}'");

    public static Error ProfilePostNotFound(string id) => Error.NotFound(
        "Profile.ProfilePostNotFound", $"Няма намерена публикация за профил с дадения идентификатор на профила: '{id}'");

    public static Error ProfileAccessNotAllowed(string id) => Error.Forbidden(
        "Profile.ProfileAccessNotAllowed", $"Нямате право да достъпвате този профил с идентификатор: '{id}'");
}