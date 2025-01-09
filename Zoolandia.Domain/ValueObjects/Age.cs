namespace Zoolandia.Domain.ValueObjects;

public record Age
{
    public int Years { get; private set; }
    
    public int Months { get; private set; }

    public Age() 
    {}
    
    private Age(int years, int months)
    {
        this.Years = years;
        this.Months = months;
    }

    public static Age Create(int years, int months)
        => new (years, months);

    public static Age Create(Age age)
        => Create(age.Years, age.Months);
}