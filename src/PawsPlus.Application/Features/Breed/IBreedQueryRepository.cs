using PawsPlus.Application.Features.Breed.Queries;

namespace PawsPlus.Application.Features.Breed;

public interface IBreedQueryRepository
{
    Task<IEnumerable<BreedOutputModel>> GetBreeds(int animalTypeId, CancellationToken cancellationToken = default);
}