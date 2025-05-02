using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Errors;

public class BookingErrors
{
    public static Error BookingNotFound(string id) => Error.NotFound(
        "Booking.BookingNotFound", $"Не е намерена резервация с този идентификатор: '{id}'");

    public static Error BookingAlreadyResolved => Error.Conflict(
        "Booking.BookingAlreadyResolved", $"Тази резервация вече е обработена");

    public static Error UnableToSendEmail => Error.Conflict(
        "Booking.UnableToSendEmail", $"Резервацията е актуализирана, но не можа да се изпрати имейл");

    public static Error OwnerPetIsNull => Error.Validation(
        "Booking.OwnerPetIsNull", $"Собственикът няма домашен любимец. Моля, създайте един, преди да резервирате гледач");
    
}