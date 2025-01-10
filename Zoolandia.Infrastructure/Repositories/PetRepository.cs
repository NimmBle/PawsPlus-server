using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zoolandia.Application.Common;
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
    public async Task<Pet> Get(string id, CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();

    // fix
    public async Task<bool> Delete(string id, CancellationToken cancellationToken = default)
    {
        var pet = await this.Get(id);

        if (pet == null)
            return false;

        this.Data.Pets.Remove(pet);

        await this.Data.SaveChangesAsync();

        return true;
    }

    public async Task<PetOutputModel> GetPetByProfile(string profileId)
    { 
        var pet = await GetPet(p => p.ProfileId == profileId);
        
        return mapper.Map<PetOutputModel>(pet);
    }

    public async Task<Pet> GetPetById(string id)
        => await this
            .All()
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();
    
    private async Task<Pet?> GetPet(Expression<Func<Pet, bool>> predicate)
        => await this
            .All()
            .Where(predicate)
            .Include(p => p.Age)
            .Include(p => p.Personality)
            .Include(p => p.HealthStatus)
            .FirstOrDefaultAsync();
}