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
    public async Task<Service> GetByName(string serviceName)
        => await db
            .Services
            .Where(s => s.Name == serviceName)
            .FirstOrDefaultAsync();

    public async Task<string> GetIdOfService(string serviceName)
        => await db
            .Services
            .Where(s => s.Name == serviceName)
            .Select(s => s.Id)
            .FirstOrDefaultAsync();
}