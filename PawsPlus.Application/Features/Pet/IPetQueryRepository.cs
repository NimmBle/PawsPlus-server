using PawsPlus.Application.Features.Pet.Queries;

namespace PawsPlus.Application.Features.Pet;

public interface IPetQueryRepository
{
    Task<PetOutputModel> GetPetByProfile(string profileId, CancellationToken cancellationToken = default);
    
}