using Zoolandia.Application.Features.Pet.Queries;

namespace Zoolandia.Application.Features.Pet;

public interface IPetQueryRepository
{
    Task<PetOutputModel> GetPetByProfile(string profileId, CancellationToken cancellationToken = default);
    
}