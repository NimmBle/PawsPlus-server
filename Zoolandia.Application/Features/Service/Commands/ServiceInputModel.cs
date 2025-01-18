using System.Collections;
using Zoolandia.Application.Common;

namespace Zoolandia.Application.Features.Service.Commands;

public abstract class ServiceInputModel : EntityCommand<string>
{
    public int? Price { get; set; }
        
    public List<DateOnly>? AvailableDates { get; set; }
}