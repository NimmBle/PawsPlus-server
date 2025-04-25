using PawsPlus.Domain.Common.Models;

namespace PawsPlus.Domain.Models;

public class BookingState : Enumeration
{
    public static readonly BookingState Pending = new BookingState(1, nameof(Pending));
    public static readonly BookingState Canceled = new BookingState(2, nameof(Canceled));
    public static readonly BookingState Disapproved = new BookingState(3, nameof(Disapproved));
    public static readonly BookingState Approved = new BookingState(4, nameof(Approved));
    public static readonly BookingState Started = new BookingState(5, nameof(Started));
    public static readonly BookingState Completed = new BookingState(6, nameof(Completed));
    
    
    private BookingState(int value)
        : base(value, FromValue<BookingState>(value).Name)
    {
    }


    public BookingState(int value,
        string name)
        : base(value, name)
    {
    }
}