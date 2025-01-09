using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zoolandia.Application.Features.Pet;
using Zoolandia.Application.Features.Pet.Queries;
using Zoolandia.Domain.Models;
using Zoolandia.Domain.Repositories;
using Zoolandia.Infrastructure.Common.Persistence;

namespace Zoolandia.Infrastructure.Repositories;

public class PetRepository
    (ZoolandiaDbContext db, 
        IMapper mapper)
        : DataRepository<ZoolandiaDbContext, Pet>(db),
            IPetDomainRepository,
            IPetQueryRepository
{
    public async Task<Pet> Find(string id, CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();

    // fix
    public async Task<bool> Delete(string id, CancellationToken cancellationToken = default)
    {
        var pet = await this.Find(id);

        if (pet == null)
            return false;

        this.Data.Pets.Remove(pet);

        await this.Data.SaveChangesAsync();

        return true;
    }

    public async Task<PetOutputModel> FindPetByProfile(string profileId)
    { 
        var pet = await this
            .All()
            .Where(p => p.ProfileId == profileId)
            .Include(p => p.Age)
            .Include(p => p.Personality)
            .Include(p => p.HealthStatus)
            .FirstOrDefaultAsync();
        
        return mapper.Map<PetOutputModel>(pet);
    }


    // => await mapper
    //     .ProjectTo<PetOutputModel>(this
    //         .All()
    //         .AsNoTracking()
    //         .Where(p => p.ProfileId == profileId))
    //     .FirstOrDefaultAsync();
}