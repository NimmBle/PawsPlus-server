using MediatR;
using PawsPlus.Application.Common;

namespace PawsPlus.Application.Features.Pet.Queries.Details;

public class GetPetDetailsQuery : IRequest<Result<PetDetailsOutputModel>>
{
    public string Id { get; set; }
    
    public class PetDetailsQueryHandler(IPetQueryRepository petQueryRepository) 
        : IRequestHandler<GetPetDetailsQuery, Result<PetDetailsOutputModel>>
    {
        public async Task<Result<PetDetailsOutputModel>> Handle(GetPetDetailsQuery request,
            CancellationToken cancellationToken)
            => await petQueryRepository.GetPetDetails(request.Id);
    }
}