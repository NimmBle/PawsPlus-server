using MediatR;
using PawsPlus.Application.Common;

namespace PawsPlus.Application.Features.Breed.Queries;

public class GetBreedsQuery : IRequest<Result<IEnumerable<BreedOutputModel>>>
{
    public int AnimalTypeId { get; set; }
    
    public class GetBreedsQueryHandler(IBreedQueryRepository breedQueryRepository)
        : IRequestHandler<GetBreedsQuery, Result<IEnumerable<BreedOutputModel>>>
    {
        public async Task<Result<IEnumerable<BreedOutputModel>>> Handle(GetBreedsQuery request,
            CancellationToken cancellationToken)
            => Result<IEnumerable<BreedOutputModel>>.SuccessWith(await breedQueryRepository.GetBreeds(request.AnimalTypeId, cancellationToken));
    }
}