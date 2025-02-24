using Microsoft.EntityFrameworkCore;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;
using PawsPlus.Infrastructure.Common.Persistence;

namespace PawsPlus.Infrastructure.Repositories;

public class MeetingPlaceRepository(ZoolandiaDbContext db)
    : DataRepository<ZoolandiaDbContext, MeetingPlace>(db),
        IMeetingPlaceDomainRepository
{
    public async Task<MeetingPlace> Find(int id, CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

    public async Task<List<MeetingPlace>> FindAll(IEnumerable<int> ids, CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(at => ids.Contains(at.Id))
            .ToListAsync(cancellationToken);
}