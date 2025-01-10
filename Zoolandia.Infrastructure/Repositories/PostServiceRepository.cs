using Microsoft.EntityFrameworkCore;
using Zoolandia.Domain.Models;
using Zoolandia.Domain.Repositories;
using Zoolandia.Infrastructure.Common.Persistence;

namespace Zoolandia.Infrastructure.Repositories;

public class PostServiceRepository(ZoolandiaDbContext db)
    : DataRepository<ZoolandiaDbContext, PostService>(db),
        IPostServiceDomainRepository
{
    public async Task<PostService> GetById(string postServiceId)
        => await db
            .PostServices
            .Where(ps => ps.Id == postServiceId)
            .FirstOrDefaultAsync();
}