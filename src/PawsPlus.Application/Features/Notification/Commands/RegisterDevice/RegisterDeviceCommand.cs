using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Application.Common.Contracts;
using PawsPlus.Application.Features.Profile;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Features.Notification.Commands.RegisterDevice;

public class RegisterDeviceCommand : IRequest<Result>
{
    public string DeviceToken { get; set; }
    
    public class RegisterDeviceCommandHandler(IDeviceTokenDomainRepository deviceTokenRepository,
        ICurrentUser currentUser,
        IProfileQueryRepository profileQueryRepository)
        : IRequestHandler<RegisterDeviceCommand, Result>
    {
        public async Task<Result> Handle(RegisterDeviceCommand request,
            CancellationToken cancellationToken)
        {
            var userId = currentUser.UserId;
            var profileId = await profileQueryRepository.GetProfileIdByUser(userId, cancellationToken);
            
            var existingToken = await deviceTokenRepository.FindDeviceTokenByProfileId(profileId);
            if (existingToken is not null)
            {
                await deviceTokenRepository.Delete(existingToken);
            }
            
            var deviceToken = new DeviceToken(profileId,
                request.DeviceToken);

            await deviceTokenRepository.Save(deviceToken);

            return true;
        }
    }
}