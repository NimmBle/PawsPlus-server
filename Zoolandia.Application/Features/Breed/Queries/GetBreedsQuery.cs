using MediatR;

namespace Zoolandia.Application.Features.Breed.Queries;

public class GetBreedsQuery : IRequest<IEnumerable<BreedOutputModel>>
{
    public string PetType { get; set; }
    
    public class GetBreedsQueryHandler(IBreedQueryRepository breedQueryRepository)
        : IRequestHandler<GetBreedsQuery, IEnumerable<BreedOutputModel>>
    {
        public async Task<IEnumerable<BreedOutputModel>> Handle(GetBreedsQuery request, CancellationToken cancellationToken)
            => await breedQueryRepository.GetBreeds(request.PetType, cancellationToken);
    }
}