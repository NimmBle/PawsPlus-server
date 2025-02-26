using Microsoft.EntityFrameworkCore;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;
using PawsPlus.Infrastructure.Common.Persistence;

namespace PawsPlus.Infrastructure.Repositories;

public class WeightRepository(ZoolandiaDbContext db)
    : DataRepository<ZoolandiaDbContext, Weight>(db),
        IWeightDomainRepository
{
    public async Task<Weight> Find(int? id, CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(w => w.Id == id, cancellationToken);

    public async Task<ICollection<Weight>> FindAll(IEnumerable<int> ids, CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(w => ids.Contains(w.Id))
            .ToListAsync(cancellationToken);
}