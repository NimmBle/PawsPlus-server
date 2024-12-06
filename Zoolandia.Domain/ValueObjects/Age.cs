namespace Zoolandia.Domain.ValueObjects;

public record Age
{
    public int Years { get; private init; }
    
    public int Months { get; private init; }

    public Age() 
    {}
    
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