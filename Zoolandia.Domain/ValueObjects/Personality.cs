using Zoolandia.Domain.Enums;

namespace Zoolandia.Domain.Models;

public record Personality
{
    
    public string Temperament { get; private set; }
    
    public string ActivityLevel { get; private set; }
    
    public Training IsTrained { get; private set; }
    
    public Fear HasFears { get; private set; }
    
    public string FearsDescription { get; private set; }

    public Personality()
    {}
    
    public Personality(
        string temperament,
        string activityLevel,
        Training isTrained,
        string fearsDescription,
        Fear hasFears)
    {
        this.Temperament = temperament;
        this.ActivityLevel = activityLevel;
        this.IsTrained = isTrained;
        this.FearsDescription = fearsDescription;
        this.HasFears = hasFears;
    }

    
    public static Personality Create(
        string temperament,
        string activityLevel,
        Training isTrained,
        string fearsDescription,
        Fear hasFears)
    {
        return new Personality(temperament, activityLevel, isTrained, fearsDescription, hasFears);
    }
}