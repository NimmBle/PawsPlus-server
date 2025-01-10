using Zoolandia.Application.Common;
using Zoolandia.Application.Features.Pet.Queries;

namespace Zoolandia.Application.Features.Pet;

public interface IPetQueryRepository
{
    Task<PetOutputModel> GetPetByProfile(string profileId);

    Task<Domain.Models.Pet> GetPetById(string id);
}