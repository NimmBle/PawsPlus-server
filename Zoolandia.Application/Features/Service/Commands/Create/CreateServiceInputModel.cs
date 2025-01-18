using Zoolandia.Domain.Enums;

namespace Zoolandia.Application.Features.Service.Commands.Create;

public class CreateServiceInputModel : ServiceInputModel
{
    public ServiceType ServiceType { get; set; }
}