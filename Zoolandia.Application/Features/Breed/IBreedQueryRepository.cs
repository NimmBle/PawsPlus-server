using Zoolandia.Application.Features.Breed.Queries;
using Zoolandia.Domain.Enums.Pet;

namespace Zoolandia.Application.Features.Breed;

public interface IBreedQueryRepository
{
    Task<IEnumerable<BreedOutputModel>> GetBreeds(PetType petType, CancellationToken cancellationToken = default);
}