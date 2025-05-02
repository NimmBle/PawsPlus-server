using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Errors;

public class PetErrors
{
    public static Error PetAccessNotAllowed => Error.Forbidden(
        "Pet.PetAccessNotAllowed", $"Нямате право да достъпвате домашните любимци на този профил");

    public static Error PetTypeNotFound => Error.NullValue;
}