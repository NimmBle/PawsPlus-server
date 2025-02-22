using MediatR;
using PawsPlus.Application.Common;
using PawsPlus.Application.Features.Pet;

namespace PawsPlus.Application.Features.Profile.Queries.MinePet;

public class GetProfilePetQuery : IRequest<Result<PetOutputModel>>
{
    public string Id { get; set; }
    
    public class GetProfilePetQueryHandler
        (IPetQueryRepository petQueryRepository)
        : IRequestHandler<GetProfilePetQuery, Result<PetOutputModel>>
    {
        public async Task<Result<PetOutputModel>> Handle(GetProfilePetQuery request, CancellationToken cancellationToken)
        {
            return await petQueryRepository.GetPetByProfile(request.Id);
        }
    }
}