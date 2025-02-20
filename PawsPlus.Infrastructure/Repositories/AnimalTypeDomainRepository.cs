using Microsoft.EntityFrameworkCore;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;
using PawsPlus.Infrastructure.Common.Persistence;

namespace PawsPlus.Infrastructure.Repositories;

public class AnimalTypeDomainRepository(ZoolandiaDbContext db)
    : DataRepository<ZoolandiaDbContext, AnimalType>(db),
        IAnimalTypeDomainRepository
{
    public async Task<AnimalType> Find(int id, CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(at => at.Id == id, cancellationToken);

    public async Task<List<AnimalType>> FindAll(IEnumerable<int> ids, CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(at => ids.Contains(at.Id))
            .ToListAsync(cancellationToken);
}