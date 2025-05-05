using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Application.Common.Contracts;
using PawsPlus.Application.Features.Profile;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Features.Notification.Commands.RegisterDevice;

public class RegisterDeviceCommand : RegisterDeviceInputModel, IRequest<Result>
{
    
    public class RegisterDeviceCommandHandler(IDeviceTokenDomainRepository deviceTokenRepository,
        ICurrentUser currentUser,
        IProfileQueryRepository profileQueryRepository)
        : IRequestHandler<RegisterDeviceCommand, Result>
    {
        public async Task<Result> Handle(RegisterDeviceCommand request,
            CancellationToken cancellationToken)
        {
            var existingToken = await deviceTokenRepository.FindDeviceTokenByProfileId(request.ProfileId);
            if (existingToken is not null)
            {
                await deviceTokenRepository.Delete(existingToken);
            }
            
            var userId = currentUser.UserId;
            var profileId = await profileQueryRepository.GetProfileIdByUser(userId, cancellationToken);
            
            var deviceToken = new DeviceToken(profileId,
                request.BookingId,
                request.DeviceToken);

            await deviceTokenRepository.Save(deviceToken);

            return true;
        }
    }
}