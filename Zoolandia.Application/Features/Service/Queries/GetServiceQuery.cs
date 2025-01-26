using MediatR;
using Zoolandia.Application.Common;

namespace Zoolandia.Application.Features.Service.Queries;

public class GetServiceQuery : IRequest<Result<ServiceOutputModel>>
{
    public string Id { get; set; }
    
    public class GetServiceQueryHandler(IServiceQueryRepository serviceQueryRepository)
        : IRequestHandler<GetServiceQuery, Result<ServiceOutputModel>>
    {
        public async Task<Result<ServiceOutputModel>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
            => await serviceQueryRepository.Get(request.Id);
    }
}