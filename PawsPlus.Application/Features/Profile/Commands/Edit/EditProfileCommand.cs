using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Application.Common.Contracts;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Features.Profile.Commands.Edit;

public class EditProfileCommand 
    : EntityCommand<string>,
        IRequest<Result>
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string PhotoUrl { get; set; }
    
    public string? Description { get; set; }
    
    public LocationInputModel Location { get; set; }
    
    
    public class EditUserCommandHandler(ICurrentUser currentUser,
        IProfileDomainRepository profileDomainRepository)
        : IRequestHandler<EditProfileCommand, Result>
    {
        public async Task<Result> Handle(EditProfileCommand request,
            CancellationToken cancellationToken)
        {
            var currentUserId = currentUser.UserId;
            var profile = await profileDomainRepository.FindByUser(currentUserId);

            if (profile == null)
            {
                return ProfileErrors.ProfileNotFound(currentUserId);
            }
            
            if (request.Id != profile.Id)
            {
                return ProfileErrors.ProfileAccessNotAllowed(request.Id);
            }

            profile
                .UpdateFirstLogin()
                .UpdateFirstName(request.FirstName)
                .UpdateLastName(request.LastName)
                .UpdatePhotoUrl(request.PhotoUrl)
                .UpdatePhoneNumber(request.PhoneNumber)
                .UpdateDescription(request.Description)
                .UpdateLocation(request.Location.PlaceId,
                    request.Location.Latitude,
                    request.Location.Longitude);
            
            await profileDomainRepository.Update(profile);

            return true;
        }
    }
}