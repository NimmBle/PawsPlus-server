using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zoolandia.Application.Features.Service;
using Zoolandia.Domain.Models;
using Zoolandia.Domain.Repositories;
using Zoolandia.Infrastructure.Common.Persistence;

namespace Zoolandia.Infrastructure.Repositories;

public class ServiceRepository(
    ZoolandiaDbContext db,
    IMapper mapper)
    : DataRepository<ZoolandiaDbContext, Service>(db),
        IServiceDomainRepository,
        IServiceQueryRepository
{
    public async Task<Service> FindByName(string serviceName)
        => await db
            .Services
            .Where(s => s.Name == serviceName)
            .FirstOrDefaultAsync();

    
    
    // Not working!!!
    public async Task<ServiceOutputModel> FindById(string serviceId)
        => await mapper
            .ProjectTo<ServiceOutputModel>(this
                .All()
                .Where(s => s.Id == serviceId))
            .FirstOrDefaultAsync();
}