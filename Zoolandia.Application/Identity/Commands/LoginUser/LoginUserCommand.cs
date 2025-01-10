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
            
            var profile = await profileRepository.GetByUser(user.Id);

            LoginOutputModel loginOutputModel = new(
                user.Id,
                user.Token,
                profile.FirstLogin,
                user.Roles);

            profile.FirstLogin = false;
            await profileRepository.Update(profile);
            
            return loginOutputModel;
        }
    }
}