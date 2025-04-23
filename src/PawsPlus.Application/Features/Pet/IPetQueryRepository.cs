using PawsPlus.Application.Features.Pet.Queries.Details;
using PawsPlus.Application.Features.Profile.Queries.MinePet;

namespace PawsPlus.Application.Features.Pet;

public interface IPetQueryRepository
{
    Task<PetOutputModel> GetPetByProfile(string profileId, CancellationToken cancellationToken = default);
    
    Task<PetDetailsOutputModel> GetPetDetails(string petId, CancellationToken cancellationToken = default);
}