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
    public async Task<Service> GetById(string id, CancellationToken cancellationToken = default)
        => await All()
            .FirstOrDefaultAsync(s => s.Id == id);

    public async Task<Service> GetByName(string serviceName, CancellationToken cancellationToken = default)
        => await All()
            .Where(s => s.Name == serviceName)
            .FirstOrDefaultAsync();

    public async Task<bool> Delete(string id, CancellationToken cancellationToken = default)
    {
        var service = await this.GetById(id);

        if (service == null)
            return false;

        this.Data.Services.Remove(service);
        
        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> AlreadyExists(string serviceName, string postId, CancellationToken cancellationToken = default)
        => await All()
            .AnyAsync(s => s.Name == serviceName && s.PostId == postId);

    public async Task<ServiceOutputModel> Get(string serviceId, CancellationToken cancellationToken = default)
        => mapper.Map<ServiceOutputModel>(await this.GetById(serviceId, cancellationToken));
}