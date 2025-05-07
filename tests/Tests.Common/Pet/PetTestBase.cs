using Bogus;
using PawsPlus.Domain.Enums.Pet;
using PawsPlus.Domain.Factories.Pet;
using PawsPlus.Domain.Models;

namespace Pawsplus.Testing.Pet;

public static class PetTestBase
{
    static PetTestBase()
    {
        Randomizer.Seed = new Random(1234);
        
        BreedFaker = new Faker<Breed>()
            .CustomInstantiator(f =>
                f.IndexFaker % 2 == 0
                    ? Breed.CreateDogBreed(f.Random.Uuid().ToString(), f.Company.CompanyName())
                    : Breed.CreateCatBreed(f.Random.Uuid().ToString(), f.Company.CompanyName())
            );
        
        Faker = new Faker();
    }

    public static Faker<Breed> BreedFaker { get; }
    public static Faker Faker { get; }
    
    public static PawsPlus.Domain.Models.Pet CreateRandomPet(IEnumerable<Breed>? overrideBreeds = null)
    {
        var breeds = overrideBreeds != null
            ? new List<Breed>(overrideBreeds)
            : BreedFaker.Generate(2);

        return new PetFactory()
            .WithName(Faker.Person.FirstName)
            .WithPhotoUrl(Faker.Internet.Avatar())
            .WithType(new Animal(
                Faker.Random.Int(1, 9999),
                Faker.Commerce.ProductName()))
            .WithAge(
                Faker.Random.Int(0, 15),
                Faker.Random.Int(0, 11))
            .WithGender(Faker.PickRandom<Gender>())
            .WithBreed(breeds)
            .WithPersonality(
                Faker.Lorem.Word(),
                Faker.Lorem.Word(),
                Faker.PickRandom<Training>(),
                Faker.PickRandom<Fear>(),
                Faker.Lorem.Sentence())
            .WithHealthStatus(
                Faker.Random.Bool(),
                Faker.Random.Bool(),
                Faker.Random.Bool(),
                Faker.Lorem.Word(),
                Faker.Lorem.Word(),
                Faker.Lorem.Sentence())
            .WithProfileId(Faker.Random.Uuid().ToString())
            .Build();
    }
}