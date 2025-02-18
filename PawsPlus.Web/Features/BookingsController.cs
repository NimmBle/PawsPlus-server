using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawsPlus.Application.Features.Booking.Commands.Approve;
using PawsPlus.Application.Features.Booking.Commands.Cancel;
using PawsPlus.Application.Features.Booking.Commands.Create;
using PawsPlus.Application.Features.Booking.Commands.Disapprove;
using PawsPlus.Application.Features.Booking.Queries;

namespace PawsPlus.Web.Features;

public class BookingsController : ApiController
{
    [HttpGet]
    [Authorize(Roles = Sitter)]
    public async Task<ActionResult<ICollection<BookingOutputModel>>> GetBookings(
        [FromRoute] GetBookingsQuery query)
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
    [Authorize(Roles = Owner)]
    [Route(Id + PathSeparator + nameof(Cancel))]
    public async Task<ActionResult> Cancel(CancelBookingCommand command)
        => await this.Send(command);


}
