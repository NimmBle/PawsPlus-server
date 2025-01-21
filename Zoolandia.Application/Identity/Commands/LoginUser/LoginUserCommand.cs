using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Domain.Repositories;

namespace Zoolandia.Application.Identity.Commands.LoginUser;

public class LoginUserCommand : UserInputModel, IRequest<Result<LoginOutputModel>>
{
    public class LoginUserCommandHandler(
        IIdentity identity,
        IProfileDomainRepository profileRepository) 
        : IRequestHandler<LoginUserCommand, 
            Result<LoginOutputModel>>
    {
        public async Task<Result<LoginOutputModel>> Handle(
            LoginUserCommand request,
            CancellationToken cancellationToken)
        {
            var result = await identity.Login(request);
            if (!result.Succeeded)
                return result.Errors;

            var user = result.Data;

            if (user.Roles.Contains("Administrator"))
                return user;

            var profile = await profileRepository.GetByUser(user.Id);

            profile.UpdateFirstLogin();
            
            user.FirstLogin = false;
            
            await profileRepository.Update(profile);
            
            return user;
        }
    }
}