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
            var deviceToken = await deviceTokenRepository.FindDeviceTokenByProfileId(request.ProfileId, cancellationToken);
            
            if (deviceToken is null)
            {
                return NotificationErrors.TokensNotFound(request.ProfileId);
            }

            var message = new Message()
            {
                Token = deviceToken.Token,
                Notification = new FirebaseAdmin.Messaging.Notification
                {
                    Title = request.Title,
                    Body = request.Body
                }
            };
            
            try
            {
                var response = await FirebaseMessaging.DefaultInstance.SendAsync(message, cancellationToken);
                
                if (!string.IsNullOrEmpty(response))
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