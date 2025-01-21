using Zoolandia.Domain.Enums;
using Zoolandia.Domain.Models;

namespace Zoolandia.Application.Features.Service.Commands.Create;

public class CreateServiceInputModel : ServiceInputModel
{
    public ServiceType ServiceType { get; set; }
    
    public string PostId { get; set; }
}