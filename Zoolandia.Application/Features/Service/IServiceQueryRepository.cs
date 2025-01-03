namespace Zoolandia.Application.Features.Service;

public interface IServiceQueryRepository
{
    Task<ServiceOutputModel> FindById(string serviceId);
}