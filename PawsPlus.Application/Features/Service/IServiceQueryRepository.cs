using PawsPlus.Application.Features.Service.Queries;

namespace PawsPlus.Application.Features.Service;

public interface IServiceQueryRepository
{
    Task<ServiceOutputModel> Get(string serviceId, CancellationToken cancellationToken = default);
    
    Task<string> GetServiceId(string profileId, string serviceType, CancellationToken cancellationToken = default);
}