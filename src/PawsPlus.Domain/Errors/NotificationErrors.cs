using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Errors;

public class NotificationErrors
{
    public static Error TokensNotFound(string id) => Error.NotFound(
        "Notification.TokensNotFound", $"Няма регистрирани устройства за тази резервация!");
    
    public static Error NotificationsNotSend(string message) => Error.Failure(
        "Notification.NotificationsNotSend", $"Нотификациите не бяха изпратени!");
    

}