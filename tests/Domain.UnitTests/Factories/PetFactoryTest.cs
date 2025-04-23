using Bogus;
using PawsPlus.Domain.Models;
using Pawsplus.Testing.Pet;
using Shouldly;

namespace Domain.UnitTests.Factories;

public class PetFactoryTest
{
        
    [Fact]
    public async Task PetFactoryBuild_Should_ReturnPet_WhenDataIsValid()
    {
        var breeds = PetTestBase.BreedFaker.Generate(2);

        var pet = PetTestBase.CreateRandomPet(breeds);
        
        pet.ShouldNotBeNull();
        pet.ShouldBeOfType<Pet>();
    }

    [Fact]
    public async Task PetFirstName_Should_BeCorrect_WhenDataIsValid()
    {
        var breeds = PetTestBase.BreedFaker.Generate(2);

        var pet = PetTestBase.CreateRandomPet(breeds);
        
        pet.ShouldNotBeNull();
        pet.Name.ShouldBe(pet.Name);
    }
}