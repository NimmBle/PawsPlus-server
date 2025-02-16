using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawsPlus.Application.Features.Booking.Commands.Create;

namespace PawsPlus.Web.Features;

[Authorize(Roles = Owner)]
public class BookingsController : ApiController
{
    [HttpPost]
    public async Task<ActionResult> Create(CreateBookingCommand command)
        => await this.Send(command);
}
