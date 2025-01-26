namespace Zoolandia.Application.Features.Service;

public interface IServiceQueryRepository
{
    Task<ServiceOutputModel> Get(string serviceId, CancellationToken cancellationToken = default);
}