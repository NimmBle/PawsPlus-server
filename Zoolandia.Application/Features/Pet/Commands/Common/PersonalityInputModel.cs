using Zoolandia.Domain.Enums.Pet;

namespace Zoolandia.Application.Features.Pet.Commands.Common;

public class PersonalityInputModel
{
    public string? Temperament { get; set; }

    public string? ActivityLevel { get; set; }
    
    public Training? IsTrained { get; set; }
    
    public Fear? HasFears { get; set; }
    
    public string? FearsDescription { get; set; }
}