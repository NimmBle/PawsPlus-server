using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawsPlus.Application.Features.Booking.Commands.Approve;
using PawsPlus.Application.Features.Booking.Commands.Cancel;
using PawsPlus.Application.Features.Booking.Commands.Complete;
using PawsPlus.Application.Features.Booking.Commands.Create;
using PawsPlus.Application.Features.Booking.Commands.Disapprove;
using PawsPlus.Application.Features.Booking.Commands.Start;
using PawsPlus.Application.Features.Booking.Queries;
using PawsPlus.Application.Features.Booking.Queries.Completed;

namespace PawsPlus.Web.Features;

public class BookingsController : ApiController
{
    [HttpGet]
    [Authorize(Roles = $"{Sitter}, {Owner}")]
    [Route(nameof(Pending))]
    public async Task<ActionResult<ICollection<BookingOutputModel>>> Pending(
        [FromRoute] GetBookingsQuery query)
        => await this.Send(query);
    
    [HttpGet]
    [Authorize(Roles = $"{Sitter}, {Owner}")]
    [Route(nameof(HaveCompletedBookings))]
    public async Task<ActionResult<bool>> HaveCompletedBookings(
        [FromQuery] GetCompletedBookingsQuery query)
        => await this.Send(query);
    
    [HttpPost]
    [Authorize(Roles = Owner)]
    public async Task<ActionResult> Create(CreateBookingCommand command)
        => await this.Send(command);

    [HttpPatch]
    [Authorize(Roles = Sitter)]
    [Route(Id + PathSeparator + nameof(Approve))]
    public async Task<ActionResult> Approve(ApproveBookingCommand command)
        => await this.Send(command);
    
    [HttpPatch]
    [Authorize(Roles = Sitter)]
    [Route(Id + PathSeparator + nameof(Disapprove))]
    public async Task<ActionResult> Disapprove(DisapproveBookingCommand command)
        => await this.Send(command);
    
    [HttpPatch]
    [Authorize(Roles = Sitter)]
    [Route(Id + PathSeparator + nameof(Start))]
    public async Task<ActionResult> Start(StartBookingCommand command)
        => await this.Send(command);
    
    [HttpPatch]
    [Authorize(Roles = Sitter)]
    [Route(Id + PathSeparator + nameof(Complete))]
    public async Task<ActionResult> Complete(CompleteBookingCommand command)
        => await this.Send(command);
    
    [HttpPatch]
    [Authorize(Roles = Owner)]
    [Route(Id + PathSeparator + nameof(Cancel))]
    public async Task<ActionResult> Cancel(CancelBookingCommand command)
        => await this.Send(command);


}
