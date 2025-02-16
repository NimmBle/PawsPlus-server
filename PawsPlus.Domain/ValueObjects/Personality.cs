using PawsPlus.Domain.Enums.Pet;

namespace PawsPlus.Domain.ValueObjects;

public record Personality
{

    public string? Temperament { get; init; }

    public string? ActivityLevel { get; init; }
    
    public Training? IsTrained { get; init; }
    
    public Fear? HasFears { get; init; }
    
    public string? FearsDescription { get; init; }

    public Personality()
    {}
    
    private Personality(
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
        => new (temperament, activityLevel, isTrained, hasFears, fearsDescription);

    public static Personality Create(Personality personality)
        => Create(
            personality.Temperament,
            personality.ActivityLevel,
            personality.IsTrained,
            personality.HasFears,
            personality.FearsDescription);
}