using Zoolandia.Domain.Common;
using Zoolandia.Domain.Models;

namespace Zoolandia.Domain.Repositories;

public interface IServiceDomainRepository : IDomainRepository<Service>
{
    Task<Service> GetByName(string serviceName);
}