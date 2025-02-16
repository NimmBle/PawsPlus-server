using MediatR;
using PawsPlus.Application.Common;

namespace PawsPlus.Application.Features.Pet.Queries;

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