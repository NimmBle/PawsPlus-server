using Zoolandia.Application.Features.Breed.Queries;

namespace Zoolandia.Application.Features.Breed;

public interface IBreedQueryRepository
{
    Task<IEnumerable<BreedOutputModel>> GetBreeds(string breedName, CancellationToken cancellationToken = default);
}