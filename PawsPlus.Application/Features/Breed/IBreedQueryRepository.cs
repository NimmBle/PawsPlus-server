using PawsPlus.Application.Features.Breed.Queries;
using PawsPlus.Domain.Enums.Pet;

namespace PawsPlus.Application.Features.Breed;

public interface IBreedQueryRepository
{
    Task<IEnumerable<BreedOutputModel>> GetBreeds(int animalTypeId, CancellationToken cancellationToken = default);
}