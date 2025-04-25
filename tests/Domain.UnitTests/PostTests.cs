using Bogus;
using PawsPlus.Domain.Models;

namespace Domain.UnitTests;

public class PostTests
{
    private readonly Faker _faker = new();
    private readonly Post _post;

    public PostTests()
    {
        List<Animal> animalTypes = new List<Animal>
        {
            new Animal(1, "Dog"),
            new Animal(2, "Cat")
        };

        List<Weight> weights = new List<Weight>
        {
            new Weight(1, "Small"),
            new Weight(2, "Medium"),
        };

        _post = new(animalTypes,
            weights,
            Guid.NewGuid().ToString());
    }

}