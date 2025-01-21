using AutoMapper;
using MediatR;
using Zoolandia.Application.Common;

namespace Zoolandia.Application.Features.Pet.Queries;

public class GetProfilePetQuery : IRequest<Result<PetOutputModel>>
{
    public string Id { get; set; }
    
    public class GetProfilePetQueryHander
        (IPetQueryRepository petQueryRepository)
        : IRequestHandler<GetProfilePetQuery, Result<PetOutputModel>>
    {
        public async Task<Result<PetOutputModel>> Handle(GetProfilePetQuery request, CancellationToken cancellationToken)
        {
            return await petQueryRepository.GetPetByProfile(request.Id);
        }
    }
}