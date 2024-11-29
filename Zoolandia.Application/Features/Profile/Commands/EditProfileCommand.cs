using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Application.Common.Contracts;
using Zoolandia.Application.Identity;
using Zoolandia.Domain.Repositories;

namespace Zoolandia.Application.Features.Profile.Commands;

public class EditProfileCommand 
    : EntityCommand<string>,
        IRequest<Result>
{
    
    public string Email { get; set; }
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string PhotoUrl { get; set; }
    
    public string Description { get; set; }
    
    public string Socials { get; set; } // not fully implemented
    
    
    public class EditUserCommandHandler(
        ICurrentUser currentUser,
        IIdentity identity,
        IProfileDomainRepository profileRepository)
        : IRequestHandler<EditProfileCommand, Result>
    {
        public async Task<Result> Handle(
            EditProfileCommand request,
            CancellationToken cancellationToken)
        {
            var currentUserId = currentUser.UserId;
            var profile = await profileRepository.FindByUser(currentUserId);
            var emailExists = await identity.EmailAlreadyExists(request.Email);

            if (profile == null)
                return false;
            
            if (request.Id != currentUserId)
                return "You cannot edit this User";

            if (emailExists)
                return "This email is taken! Try another";
            
            await identity.ChangeEmail(currentUserId, request.Email);
            
            profile
                .UpdateFirstName(request.FirstName)
                .UpdateLastName(request.LastName)
                .UpdatePhotoUrl(request.PhotoUrl)
                .UpdatePhoneNumber(request.PhoneNumber)
                .UpdateDescription(request.Description);
            
            await profileRepository.Update(profile);

            return true;
        }
    }
}