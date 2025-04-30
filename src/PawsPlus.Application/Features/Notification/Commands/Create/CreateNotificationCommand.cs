using System.Reflection;
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
            var tokens = await deviceTokenRepository.FindDeviceTokensByBookingId(request.BookingId);
            
            if (!tokens.Any())
            {
                return NotificationErrors.TokensNotFound(request.BookingId);
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
                    { "bookingId", request.BookingId }
                }
            };
            
            try
            {
                var response = await FirebaseMessaging.DefaultInstance.SendMulticastAsync(message);
                return Result.Success;
            }
            catch (Exception ex)
            {
                return NotificationErrors.NotificationsNotSend();
            }
            
        }
    }
}