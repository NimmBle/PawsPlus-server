using Zoolandia.Application.Common;
using Zoolandia.Application.Features.Pet.Queries;

namespace Zoolandia.Application.Features.Pet;

public interface IPetQueryRepository
{
    Task<PetOutputModel> FindPetByProfile(string profileId);

    Task<Domain.Models.Pet> FindPetById(string id);
}