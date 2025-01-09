using Zoolandia.Domain.Enums.Pet;

namespace Zoolandia.Domain.ValueObjects;

public record Personality
{

    public string? Temperament { get; private set; }

    public string? ActivityLevel { get; private set; }
    
    public Training? IsTrained { get; private set; }
    
    public Fear? HasFears { get; private set; }
    
    public string? FearsDescription { get; private set; }

    public Personality()
    {}
    
    public Personality(
        string? temperament,
        string? activityLevel,
        Training? isTrained,
        Fear? hasFears,
        string? fearsDescription)
    {
        this.Temperament = temperament;
        this.ActivityLevel = activityLevel;
        this.IsTrained = isTrained;
        this.HasFears = hasFears;
        this.FearsDescription = fearsDescription;
    }

    
    public static Personality Create(
        string? temperament,
        string? activityLevel,
        Training? isTrained,
        Fear? hasFears,
        string? fearsDescription)
    {
        return new Personality(temperament, activityLevel, isTrained, hasFears, fearsDescription);
    }
}