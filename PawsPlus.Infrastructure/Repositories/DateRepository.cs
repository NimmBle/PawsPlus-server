using Microsoft.EntityFrameworkCore;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;
using PawsPlus.Infrastructure.Common.Persistence;

namespace PawsPlus.Infrastructure.Repositories;

public class DateRepository(ZoolandiaDbContext db)
    : DataRepository<ZoolandiaDbContext, Date>(db),
        IDateDomainRepository
{
    public Task<bool> CreateDate(Date date)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Date>> FindAll(DateOnly minDate,
        DateOnly maxDate,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(d => d.Day >= minDate && d.Day <= maxDate)
            .ToListAsync(cancellationToken);
}