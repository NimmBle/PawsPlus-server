namespace Zoolandia.Application.Features.Service;

public interface IServiceQueryRepository
{
    Task<Domain.Models.Service> GetServiceByName(string serviceName);
}