using PawsPlus.Domain.Enums;

namespace PawsPlus.Application.Features.Service.Commands.Create;

public class CreateServiceInputModel : ServiceInputModel
{
    public ServiceType ServiceType { get; set; }
    
    public string PostId { get; set; }
}