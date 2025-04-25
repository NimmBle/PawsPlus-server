using Bogus;
using PawsPlus.Domain.Enums;
using PawsPlus.Domain.Exceptions;
using PawsPlus.Domain.Models;
using Shouldly;

namespace Domain.UnitTests;

public class ServiceTests
{
    private readonly Faker _faker = new();
    private readonly Service _service;

    public ServiceTests()
    {
        var allDates = new List<Date>();
        var meetingPlace = new List<MeetingPlace>();
        _service = new Service(_faker.Random.Enum<ServiceType>(),
            _faker.Random.Int(1, 100),
            new List<DateOnly>
            {
                DateOnly.FromDateTime(DateTime.Today),
                DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
                DateOnly.FromDateTime(DateTime.Today.AddDays(2)),
                DateOnly.FromDateTime(DateTime.Today.AddDays(3))
            },
            meetingPlace,
            Guid.NewGuid().ToString(),
            allDates);
    }

    [Theory]
    [InlineData(-10)]
    [InlineData(-100)]
    public async Task UpdatePrice_Should_ThrowException_WhenPriceIsNegative(int newPrice)
    {
        Should.Throw<InvalidServiceException>(() => _service.UpdatePrice(newPrice));
    }
    
    [Theory]
    [InlineData(1)]
    [InlineData(99)]
    [InlineData(111)]
    public async Task UpdatePrice_Should_Update_WhenPriceIsValid(int newPrice)
    {
        _service.UpdatePrice(newPrice);
        _service.Price.ShouldBe(newPrice);
    }
}