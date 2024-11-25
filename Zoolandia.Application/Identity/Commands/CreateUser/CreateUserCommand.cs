using MediatR;
using Zoolandia.Application.Common;
using static Zoolandia.Domain.Models.ModelConstants;
using Zoolandia.Domain.Repositories;
using Profile = Zoolandia.Domain.Models.Profile;

namespace Zoolandia.Application.Identity.Commands.CreateUser;

public class CreateUserCommand : UserInputModel, IRequest<Result>
{
    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string PhoneNumber { get; set; } = default!;

    public Role Role { get; set; } = default!;
    
    public class CreateUserCommandHandler(
            IIdentity identity,
            IProfileDomainRepository profileRepository) 
        : IRequestHandler<CreateUserCommand, Result>
    {
        public async Task<Result> Handle(
            CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var result = await identity.Register(request);

            if (!result.Succeeded)
                return Result.Failure(result.Errors); // remove Result.Failure after implementing IUser

            var user = result.Data;
            
            Profile profile = new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber
            };
            
            user.CreateProfile(profile);

            await profileRepository.Save(profile, cancellationToken);

            return result;
        }
    }
}