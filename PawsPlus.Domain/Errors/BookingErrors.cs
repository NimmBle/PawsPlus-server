using PawsPlus.Domain.Common;

namespace PawsPlus.Domain.Errors;

public class BookingErrors
{
    public static Error BookingNotFound(string id) => Error.NotFound(
        "Booking.BookingNotFound", $"No booking was found with this id: '{id}'");

    public static Error NoPendingBookings => Error.NotFound(
        "Booking.NoPendingBookings", $"You have no more pending bookings");
    
    public static Error BookingAlreadyResolved => Error.Conflict(
        "Booking.BookingAlreadyResolved", $"This booking has already been resolved");
    
    public static Error UnableToSendEmail => Error.Conflict(
        "Booking.UnableToSendEmail", $"The booking has been updated, but could not send email"); 
}