using Microsoft.EntityFrameworkCore;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;
using PawsPlus.Infrastructure.Common.Persistence;

namespace PawsPlus.Infrastructure.Repositories;

public class AnimalTypeRepository(ZoolandiaDbContext db)
    : DataRepository<ZoolandiaDbContext, Animal>(db),
        IAnimalTypeDomainRepository
{
    public async Task<Animal> Find(int id, CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(at => at.Id == id, cancellationToken);

    public async Task<List<Animal>> FindAll(IEnumerable<int> ids, CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(at => ids.Contains(at.Id))
            .ToListAsync(cancellationToken);
}