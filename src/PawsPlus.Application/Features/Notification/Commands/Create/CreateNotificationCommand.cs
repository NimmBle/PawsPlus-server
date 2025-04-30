using FirebaseAdmin.Messaging;
using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Features.Notification.Commands.Create;

public class CreateNotificationCommand : CreateNotificationInputModel, IRequest<Result>
{
    
    public class CreateNotificationCommandHandler(IDeviceTokenDomainRepository deviceTokenRepository)
        : IRequestHandler<CreateNotificationCommand, Result>
    {
        public async Task<Result> Handle(CreateNotificationCommand request,
            CancellationToken cancellationToken)
        {
            var tokens = await deviceTokenRepository.FindDeviceTokenByProfileId(request.ProfileId);
            
            if (!tokens.Any())
            {
                return NotificationErrors.TokensNotFound(request.ProfileId);
            }

            var message = new MulticastMessage
            {
                Tokens = tokens,
                Notification = new FirebaseAdmin.Messaging.Notification
                {
                    Title = request.Title,
                    Body = request.Body
                },
                Data = new Dictionary<string, string>
                {
                    { "profileId", request.ProfileId }
                }
            };
            
            try
            {
                var response = await FirebaseMessaging.DefaultInstance.SendMulticastAsync(message);
                
                if (response.FailureCount == 0)
                {
                    return Result.Success;
                }
                
                return NotificationErrors.NotificationsNotSend("More than one failure Count");
            }
            catch (Exception ex)
            {
                return NotificationErrors.NotificationsNotSend("Ax exception occured while trying to send the notification!");
            }
        }
    }
}