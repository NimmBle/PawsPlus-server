using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawsPlus.Application.Features.Service;
using PawsPlus.Application.Features.Service.Queries;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;
using PawsPlus.Infrastructure.Common.Persistence;

namespace PawsPlus.Infrastructure.Repositories;

public class ServiceRepository(
    ZoolandiaDbContext db,
    IMapper mapper)
    : DataRepository<ZoolandiaDbContext, Service>(db),
        IServiceDomainRepository,
        IServiceQueryRepository
{
    public async Task<Service> Find(string id,
        CancellationToken cancellationToken = default)
        => await All()
            .FirstOrDefaultAsync(s => s.Id == id);

    public async Task<bool> Delete(string id,
        CancellationToken cancellationToken = default)
    {
        var service = await this.Find(id);

        if (service == null)
            return false;

        this.Data.Services.Remove(service);
        
        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<bool> AlreadyExists(string serviceName,
        string postId,
        CancellationToken cancellationToken = default)
        => await All()
            .AnyAsync(s => s.Name == serviceName && s.PostId == postId);

    public async Task<ServiceOutputModel> Get(string serviceId,
        CancellationToken cancellationToken = default)
        => mapper
            .Map<ServiceOutputModel>(await this.Find(serviceId, cancellationToken));
}