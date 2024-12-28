using Microsoft.EntityFrameworkCore;
using Zoolandia.Application.Features.Service;
using Zoolandia.Domain.Models;
using Zoolandia.Domain.Repositories;
using Zoolandia.Infrastructure.Common.Persistence;

namespace Zoolandia.Infrastructure.Repositories;

public class ServiceRepository(ZoolandiaDbContext db)
    : DataRepository<ZoolandiaDbContext, Service>(db),
        IServiceDomainRepository,
        IServiceQueryRepository
{
    public async Task<Service> GetServiceByName(string serviceName)
        => await db
            .Services
            .Where(s => s.Name == serviceName)
            .FirstOrDefaultAsync();
}