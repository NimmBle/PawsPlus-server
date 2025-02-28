using PawsPlus.Domain.Common.Models;
using PawsPlus.Domain.Exceptions;

namespace PawsPlus.Domain.ValueObjects;

public record Age
{
    public Age()
    {
    }
    
    private Age(int years,
        int months)
    {
        Guard.ForNegativeNumber<InvalidPetException>(years, nameof(Years));
        Guard.ForNegativeNumber<InvalidPetException>(months, nameof(Months));
        
        this.Years = years;
        this.Months = months;
    }
    
    public int Years { get; init; }
    
    public int Months { get; init; }

    public static Age? Create(int years, int months)
        => new Age(years, months);

    public static Age? Create(Age age)
        => Create(age.Years, age.Months);
}