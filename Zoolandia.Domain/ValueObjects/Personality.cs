using Zoolandia.Domain.Enums;

namespace Zoolandia.Domain.Models;

public record Personality
{
    
    private string Temperament { get; init; }
    
    private string Trait { get; init; }
    
    private string ActivityLevel { get; init; }
    
    private Fear HasFears { get; init; }
    
    private string FearsDescription { get; init; }

    public Personality()
    {}
    
    public Personality(
        string temperament,
        string trait,
        string activityLevel,
        string fearsDescription,
        Fear hasFears)
    {
        this.Temperament = temperament;
        this.Trait = trait;
        this.ActivityLevel = activityLevel;
        this.FearsDescription = fearsDescription;
        this.HasFears = hasFears;
    }

    
    public static Personality Create(
        string temperament,
        string trait,
        string activityLevel,
        string fearsDescription,
        Fear hasFears)
    {
        return new Personality(temperament, trait, activityLevel, fearsDescription, hasFears);
    }
}