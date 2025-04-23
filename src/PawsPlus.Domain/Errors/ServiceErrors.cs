using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Errors;

public class ServiceErrors
{
    public static Error ServiceAlreadyExists => Error.Conflict(
        "Services.ServiceAlreadyExists", "The service you want to create already exists"); 
    
    public static Error ServiceNotFound => Error.NotFound(
        "Services.ServiceNotFound", $"The service you want to edit or delete was not found. Make sure it exists.");

    public static Error InvalidMeetingPlace => Error.Validation(
        "Services.InvalidMeetingPlace", "Invalid place cannot be null or empty");
    
    public static Error NonExistingMeetingPlace => Error.Validation(
        "Services.InvalidMeetingPlace", "Invalid place is not available for this service.");
    
    public static Error InvalidAvailableDates => Error.Validation(
        "Services.InvalidAvailableDates", "Sitter is not available on these dates");
}