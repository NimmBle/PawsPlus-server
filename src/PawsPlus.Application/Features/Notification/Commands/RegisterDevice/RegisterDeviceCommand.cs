using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Features.Notification.Commands.RegisterDevice;

public class RegisterDeviceCommand : RegisterDeviceInputModel, IRequest<Result>
{
    
    public class RegisterDeviceCommandHandler(IDeviceTokenDomainRepository deviceTokenRepository)
        : IRequestHandler<RegisterDeviceCommand, Result>
    {
        public async Task<Result> Handle(RegisterDeviceCommand request,
            CancellationToken cancellationToken)
        {
            var deviceToken = new DeviceToken(request.ProfileId,
                request.BookingId,
                request.DeviceToken);

            await deviceTokenRepository.Save(deviceToken);

            return true;
        }
    }
}