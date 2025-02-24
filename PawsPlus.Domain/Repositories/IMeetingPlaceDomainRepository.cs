using PawsPlus.Domain.Common;
using PawsPlus.Domain.Models;

namespace PawsPlus.Domain.Repositories;

public interface IMeetingPlaceDomainRepository : IDomainRepository<MeetingPlace>
{
    Task<MeetingPlace> Find(int id, CancellationToken cancellationToken = default);
    Task<List<MeetingPlace>> FindAll(IEnumerable<int> ids, CancellationToken cancellationToken = default);
}