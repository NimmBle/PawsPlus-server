using Bogus;
using PawsPlus.Domain.Enums.Pet;
using PawsPlus.Domain.Exceptions;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.ValueObjects;
using Shouldly;
using Xunit.Abstractions;

namespace Domain.UnitTests;

public class PetTests
{
    private readonly Pet _pet;
    private readonly Faker _faker = new Faker();
    private readonly ITestOutputHelper _testOutputHelper;

    public PetTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _pet = new Pet(
            name: "Buddy",
            photoUrl: "https://res.cloudinary.com/ds95qikmm/image/upload/v1740853041/pet.jpg",
            animal: new Animal(43, "Test"),
            gender: Gender.Male,
            weight: null,
            profileId: Guid.NewGuid().ToString()
        )
        .UpdateAge(Age.Create(2, 4))
        .UpdateBreeds(new List<Breed> { Breed.CreateCatBreed("1", _faker.Name.FirstName()) })
        .UpdateWeight(new Weight(2, "Something"))
        .UpdatePersonality(Personality.Create("Friendly", "High", Training.Yes, Fear.No, null))
        .UpdateHealthStatus(HealthStatus.Create(true, false, false, null, null, null));
    }

    [Theory]
    [InlineData("")]
    [InlineData("A")]
    [InlineData("PetNameThatIsMoreThan20CharactersLong")]
    public void UpdateName_Should_ThrowException_WhenNameIsInvalid(string newName)
    {
        Should.Throw<InvalidPetException>(() => _pet.UpdateName(newName));
    }

    [Theory]
    [InlineData("Max")]
    [InlineData("ТестовоИме")]
    [InlineData("Buddy123")]
    public void UpdateName_Should_Update_WhenNameIsValid(string newName)
    {
        _pet.UpdateName(newName);
        _pet.Name.ShouldBe(newName);
    }

    [Theory]
    [InlineData("")]
    [InlineData("notaurl")]
    [InlineData("http//missing-colon.com")]
    public void UpdatePhotoUrl_Should_ThrowException_WhenUrlIsInvalid(string newUrl)
    {
        Should.Throw<InvalidPetException>(() => _pet.UpdatePhotoUrl(newUrl));
    }

    [Theory]
    [InlineData("http://example.com/pet.png")]
    [InlineData("https://cdn.site.com/photo.jpeg")]
    public void UpdatePhotoUrl_Should_Update_WhenUrlIsValid(string newUrl)
    {
        _pet.UpdatePhotoUrl(newUrl);
        _pet.PhotoUrl.ShouldBe(newUrl);
    }

    [Theory]
    [InlineData(1, "Dog")]
    [InlineData(2, "Cat")]
    public void UpdateAnimal_Should_Update_WhenValid(int id, string name)
    {
        var animal = new Animal(id, name);
        
        _pet.UpdateAnimal(animal);
        _pet.Animal.ShouldBe(animal);
    }

    [Theory]
    [InlineData(Gender.Male)]
    [InlineData(Gender.Female)]
    public void UpdateGender_Should_Update_WhenValid(Gender newGender)
    {
        _pet.UpdateGender(newGender);
        _pet.Gender.ShouldBe(newGender);
    }

    [Fact]
    public void UpdateBreeds_Should_Update_WhenValid()
    {
        var newBreeds = new List<Breed> { Breed.CreateCatBreed("2", "CatBreedTest"), Breed.CreateDogBreed("3", "DogBreedTest") };

        _pet.UpdateBreeds(newBreeds);

        _pet.Breeds.ShouldBe(newBreeds);
        _pet.Breeds.Count.ShouldBe(2);
    }

    [Fact]
    public void UpdateBreeds_Should_SetEmpty_WhenNull()
    {
        _pet.UpdateBreeds(null);

        _pet.Breeds.ShouldBeEmpty();
    }

    [Fact]
    public void UpdateWeight_Should_Update_WhenValid()
    {
        var newWeight = new Weight(14, "Medium");

        _pet.UpdateWeight(newWeight);

        _pet.Weight.ShouldBe(newWeight);
    }

    [Fact]
    public void UpdateWeight_Should_SetNull_WhenNull()
    {
        _pet.UpdateWeight(null);

        _pet.Weight.ShouldBeNull();
    }

    [Fact]
    public void UpdatePersonality_Should_Update_WhenValid()
    {
        var training = _faker.Random.Enum<Training>();
        var fear = _faker.Random.Enum<Fear>();
        
        var newPersonality = Personality.Create(
            temperament: "Playful",
            activityLevel: "Moderate",
            isTrained: training,
            hasFears: fear,
            fearsDescription: "Afraid of loud noises");

        _pet.UpdatePersonality(newPersonality);

        _pet.Personality.ShouldBe(newPersonality);
        _pet.Personality.Temperament.ShouldBe("Playful");
        _pet.Personality.ActivityLevel.ShouldBe("Moderate");
        _pet.Personality.IsTrained.ShouldBe(training);
        _pet.Personality.HasFears.ShouldBe(fear);
        _pet.Personality.FearsDescription.ShouldBe("Afraid of loud noises");
    }

    [Fact]
    public void UpdatePersonality_Should_Update_WhenPartialValues()
    {
        var fear = _faker.Random.Enum<Fear>();
        
        var newPersonality = Personality.Create(
            temperament: null,
            activityLevel: "Low",
            isTrained: null,
            hasFears: fear,
            fearsDescription: null);

        _pet.UpdatePersonality(newPersonality);

        _pet.Personality.ShouldBe(newPersonality);
        _pet.Personality.Temperament.ShouldBeNull();
        _pet.Personality.ActivityLevel.ShouldBe("Low");
        _pet.Personality.IsTrained.ShouldBeNull();
        _pet.Personality.HasFears.ShouldBe(fear);
        _pet.Personality.FearsDescription.ShouldBeNull();
    }

    [Fact]
    public void UpdateHealthStatus_Should_Update_WhenValid()
    {
        var newHealthStatus = HealthStatus.Create(
            isVaccinated: false,
            isCastrated: true,
            takesMedications: true,
            hasEatingSchedule: "Twice daily",
            otherDietaryNeeds: "Grain-free diet",
            healthProblems: "Mild allergies");

        _pet.UpdateHealthStatus(newHealthStatus);

        _pet.HealthStatus.ShouldBe(newHealthStatus);
        _pet.HealthStatus.IsVaccinated.ShouldBe(false);
        _pet.HealthStatus.IsCastrated.ShouldBe(true);
        _pet.HealthStatus.TakesMedications.ShouldBe(true);
        _pet.HealthStatus.HasEatingSchedule.ShouldBe("Twice daily");
        _pet.HealthStatus.OtherDietaryNeeds.ShouldBe("Grain-free diet");
        _pet.HealthStatus.HealthProblems.ShouldBe("Mild allergies");
    }

    [Fact]
    public void UpdateHealthStatus_Should_Update_WhenPartialValues()
    {
        var newHealthStatus = HealthStatus.Create(
            isVaccinated: null,
            isCastrated: false,
            takesMedications: null,
            hasEatingSchedule: null,
            otherDietaryNeeds: "No dairy",
            healthProblems: null);

        _pet.UpdateHealthStatus(newHealthStatus);

        _pet.HealthStatus.ShouldBe(newHealthStatus);
        _pet.HealthStatus.IsVaccinated.ShouldBeNull();
        _pet.HealthStatus.IsCastrated.ShouldBe(false);
        _pet.HealthStatus.TakesMedications.ShouldBeNull();
        _pet.HealthStatus.HasEatingSchedule.ShouldBeNull();
        _pet.HealthStatus.OtherDietaryNeeds.ShouldBe("No dairy");
        _pet.HealthStatus.HealthProblems.ShouldBeNull();
    }

    [Fact]
    public void UpdateAge_Should_Update_WhenValid()
    {
        var newAge = Age.Create(3, 6);

        _pet.UpdateAge(newAge);

        _pet.Age.ShouldBe(newAge);
    }

    [Fact]
    public void UpdateMethods_Should_SupportChaining()
    {
        var training = _faker.Random.Enum<Training>();
        var fear = _faker.Random.Enum<Fear>();
        
        var newName = "Rover";
        var newUrl = "https://example.com/newpet.jpg";
        var newAnimal = new Animal(1, "AnimaTest");
        var newAge = Age.Create(3, 4);
        var newGender = Gender.Female;
        var newBreeds = new List<Breed> { Breed.CreateCatBreed("1", _faker.Name.FirstName()) };
        var newWeight = new Weight(2, "TestWeight");
        var newPersonality = Personality.Create("Curious", "Low", training, fear, null);
        var newHealthStatus = HealthStatus.Create(true, true, false, null, null, null);

        _pet.UpdateName(newName)
            .UpdatePhotoUrl(newUrl)
            .UpdateAnimal(newAnimal)
            .UpdateAge(newAge)
            .UpdateGender(newGender)
            .UpdateBreeds(newBreeds)
            .UpdateWeight(newWeight)
            .UpdatePersonality(newPersonality)
            .UpdateHealthStatus(newHealthStatus);

        _pet.Name.ShouldBe(newName);
        _pet.PhotoUrl.ShouldBe(newUrl);
        _pet.Animal.ShouldBe(newAnimal);
        _pet.Age.ShouldBe(newAge);
        _pet.Gender.ShouldBe(newGender);
        _pet.Breeds.ShouldBe(newBreeds);
        _pet.Weight.ShouldBe(newWeight);
        _pet.Personality.ShouldBe(newPersonality);
        _pet.HealthStatus.ShouldBe(newHealthStatus);
    }
}