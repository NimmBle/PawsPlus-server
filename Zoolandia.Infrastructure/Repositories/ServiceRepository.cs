using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zoolandia.Domain.Models;
using Zoolandia.Domain.Repositories;
using Zoolandia.Infrastructure.Common.Persistence;

namespace Zoolandia.Infrastructure.Repositories;

public class ServiceRepository(
    ZoolandiaDbContext db,
    IMapper mapper)
    : DataRepository<ZoolandiaDbContext, Service>(db),
        IServiceDomainRepository
{
    public async Task<Service> FindByName(string serviceName)
        => await db
            .Services
            .Where(s => s.Name == serviceName)
            .FirstOrDefaultAsync();
}