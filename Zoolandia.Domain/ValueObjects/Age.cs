namespace Zoolandia.Domain.ValueObjects;

public record Age
{
    private int Years { get; init; }
    
    private int Months { get; init; }

    private Age(int years, int months)
    {
        this.Years = years;
        this.Months = months;
    }

    public static Age Create(int years, int months)
    {
        return new Age(years, months);
    }
}