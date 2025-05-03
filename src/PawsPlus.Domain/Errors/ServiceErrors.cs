using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Errors;

public class ServiceErrors
{
    public static Error ServiceAlreadyExists => Error.Conflict(
        "Services.ServiceAlreadyExists", "Услугата, която се опитвате да създадете, вече съществува"); 

    public static Error ServiceNotFound => Error.NotFound(
        "Services.ServiceNotFound", "Услугата, която се опитвате да редактирате или изтриете, не беше открита. Уверете се, че съществува.");

    public static Error InvalidMeetingPlace => Error.Validation(
        "Services.InvalidMeetingPlace", "Невалидно място – не може да бъде null или празно");

    public static Error NonExistingMeetingPlace => Error.Validation(
        "Services.InvalidMeetingPlace", "Невалидно място – не е налично за тази услуга.");

    public static Error InvalidAvailableDates => Error.Validation(
        "Services.InvalidAvailableDates", "Гледачът не е свободен на тези дати");

}