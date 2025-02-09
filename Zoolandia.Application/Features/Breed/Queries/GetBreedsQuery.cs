using MediatR;
using Zoolandia.Domain.Enums.Pet;

namespace Zoolandia.Application.Features.Breed.Queries;

public class GetBreedsQuery : IRequest<IEnumerable<BreedOutputModel>>
{
    public PetType PetType { get; set; }
    
    public class GetBreedsQueryHandler(IBreedQueryRepository breedQueryRepository)
        : IRequestHandler<GetBreedsQuery, IEnumerable<BreedOutputModel>>
    {
        public async Task<IEnumerable<BreedOutputModel>> Handle(GetBreedsQuery request, CancellationToken cancellationToken)
            => await breedQueryRepository.GetBreeds(request.PetType, cancellationToken);
    }
}