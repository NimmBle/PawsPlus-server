using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawsPlus.Application.Features.Pet;
using PawsPlus.Application.Features.Pet.Queries.Details;
using PawsPlus.Application.Features.Profile.Queries.MinePet;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;
using PawsPlus.Infrastructure.Common.Persistence;

namespace PawsPlus.Infrastructure.Repositories;

public class PetRepository
    (ZoolandiaDbContext db, 
        IMapper mapper)
        : DataRepository<ZoolandiaDbContext, Pet>(db),
            IPetDomainRepository,
            IPetQueryRepository
{
    public async Task<Pet> Find(string id,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(p => p.Id == id)
            .Include(p => p.Breeds)
            .Include(p => p.Age)
            .Include(p => p.HealthStatus)
            .Include(p => p.Personality)
            .FirstOrDefaultAsync(cancellationToken);
    
    public async Task<bool> Delete(string id,
        CancellationToken cancellationToken = default)
    {
        var pet = await this.Find(id);

        if (pet == null)
            return false;

        this.Data.Pets.Remove(pet);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<PetOutputModel> GetPetByProfile(string profileId, CancellationToken cancellationToken = default)
         => mapper.Map<PetOutputModel>(await GetPet(p => p.ProfileId == profileId));

    public async Task<PetDetailsOutputModel> GetPetDetails(string petId, CancellationToken cancellationToken = default)
        => mapper.Map<PetDetailsOutputModel>(await GetPet(p => p.Id == petId));


    private async Task<Pet?> GetPet(Expression<Func<Pet, bool>> predicate,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(predicate)
            .Include(p => p.Age)
            .Include(p => p.Personality)
            .Include(p => p.HealthStatus)
            .Include(p => p.Breeds)
            .Include(p => p.Animal)
            .FirstOrDefaultAsync(cancellationToken);
}