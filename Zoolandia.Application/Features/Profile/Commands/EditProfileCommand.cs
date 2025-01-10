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
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string PhotoUrl { get; set; }
    
    public string? Description { get; set; }
    
    
    public class EditUserCommandHandler(
        ICurrentUser currentUser,
        IProfileDomainRepository profileRepository)
        : IRequestHandler<EditProfileCommand, Result>
    {
        public async Task<Result> Handle(
            EditProfileCommand request,
            CancellationToken cancellationToken)
        {
            var currentUserId = currentUser.UserId;
            var profile = await profileRepository.GetByUser(currentUserId);

            if (profile == null)
                return false;
            
            if (request.Id != profile.Id)
                return "You cannot edit this User";
            
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