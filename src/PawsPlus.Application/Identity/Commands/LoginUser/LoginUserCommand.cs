using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Domain.Repositories;

namespace PawsPlus.Application.Identity.Commands.LoginUser;

public class LoginUserCommand 
    : UserInputModel,
        IRequest<Result<LoginOutputModel>>
{
    public class LoginUserCommandHandler(IIdentity identity,
        IProfileDomainRepository profileDomainRepository) 
        : IRequestHandler<LoginUserCommand, 
            Result<LoginOutputModel>>
    {
        public async Task<Result<LoginOutputModel>> Handle(LoginUserCommand request,
            CancellationToken cancellationToken)
        {
            var result = await identity.Login(request);
            if (!result.Succeeded)
            {
                return result.Error; 
            }
            
            var user = result.Data;

            if (user.Roles.Contains("Administrator"))
            {
                return user; 
            }

            var profile = await profileDomainRepository.FindByUser(user.Id);
            
            user.FirstLogin = profile.FirstLogin;
            
            return user;
        }
    }
}