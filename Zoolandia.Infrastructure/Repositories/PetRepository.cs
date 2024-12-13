using Microsoft.EntityFrameworkCore;
using Zoolandia.Domain.Models;
using Zoolandia.Domain.Repositories;
using Zoolandia.Infrastructure.Common.Persistence;

namespace Zoolandia.Infrastructure.Repositories;

public class PetRepository
    (ZoolandiaDbContext db)
        : DataRepository<ZoolandiaDbContext, Pet>(db),
            IPetDomainRepository
{
    public async Task<Pet> Find(string id, CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();

    public async Task<bool> Delete(string id, CancellationToken cancellationToken = default)
    {
        var pet = await this.Find(id);

        if (pet == null)
            return false;

        this.Data.Pets.Remove(pet);

        await this.Data.SaveChangesAsync();

        return true;
    }
}