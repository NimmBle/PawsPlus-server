using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zoolandia.Domain.Models;
using Zoolandia.Domain.Repositories;
using Zoolandia.Infrastructure.Common.Persistence;

namespace Zoolandia.Infrastructure.Repositories;

public class ServiceRepository(
    ZoolandiaDbContext db)
    : DataRepository<ZoolandiaDbContext, Service>(db),
        IServiceDomainRepository
{
    public async Task<Service> GetById(string id)
        => await db
            .Services
            .Where(s => s.Id == id)
            .FirstOrDefaultAsync();

    public async Task<Service> GetByName(string serviceName)
        => await All()
            .Where(s => s.Name == serviceName)
            .FirstOrDefaultAsync();
}