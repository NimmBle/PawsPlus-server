using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Enums;
using PawsPlus.Domain.Repositories;
using Profile = PawsPlus.Domain.Models.Profile;

namespace PawsPlus.Application.Identity.Commands.CreateUser;

public class CreateUserCommand 
    : UserInputModel,
        IRequest<Result>
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string PhoneNumber { get; set; } = default!;

    public Role Role { get; set; } = default!;
    
    public class CreateUserCommandHandler(IIdentity identity,
            IProfileDomainRepository profileRepository) 
        : IRequestHandler<CreateUserCommand, Result>
    {
        public async Task<Result> Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var result = await identity.Register(request.Email,
                request.FirstName,
                request.LastName,
                request.Password,
                request.Role.ToString());

            if (!result.Succeeded)
            {
                return result.Error;
            }
                

            var user = result.Data;
            
            var profile = new Profile(request.FirstName,
                request.LastName,
                request.PhoneNumber
            );
            
            user.CreateProfile(profile);

            await profileRepository.Save(profile, cancellationToken);

            return result;
        }
    }
}