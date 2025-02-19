using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Errors;

public class PetErrors
{
    public static Error PetAccessNotAllowed => Error.Forbidden(
        "Pet.PetAccessNotAllowed", $"You are not allowed to access the pets of this profile");
}