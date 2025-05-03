using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawsPlus.Application.Features.Notification.Commands.Create;
using PawsPlus.Application.Features.Notification.Commands.RegisterDevice;

namespace PawsPlus.Web.Features;

[AllowAnonymous]
public class NotificationsController : ApiController
{

    [HttpPost]
    [Route(nameof(RegisterDevice))]
    public async Task<ActionResult> RegisterDevice(RegisterDeviceCommand command)
        => await this.Send(command);
    
    [HttpPost]
    [Route(nameof(Create))]
    public async Task<ActionResult> Create(CreateNotificationCommand command)
        => await this.Send(command);
}