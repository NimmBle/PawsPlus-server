using Microsoft.EntityFrameworkCore;
using Zoolandia.Domain.Common;

namespace Zoolandia.Infrastructure.Common.Persistence;

public class DataRepository<TDbContext, TEntity>(TDbContext db)
    : IDomainRepository<TEntity>
    where TDbContext : DbContext
    where TEntity : class, IAggregateRoot
{

    protected TDbContext Data { get; } = db;

    protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();
    
    public async Task Save(
        TEntity entity,
        CancellationToken cancellationToken = default)
    {
        await Data.Set<TEntity>().AddAsync(entity, cancellationToken);
        
        await Data.SaveChangesAsync(cancellationToken);
    }

    public async Task Update(TEntity entity, CancellationToken cancellationToken = default)
    {
        Data.Set<TEntity>().Update(entity);

        await Data.SaveChangesAsync(cancellationToken);
    }
}