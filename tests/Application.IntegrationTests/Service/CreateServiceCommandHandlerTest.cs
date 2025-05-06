using Microsoft.EntityFrameworkCore;
using PawsPlus.Application.Features.Service.Commands.Create;
using PawsPlus.Domain.Enums;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Models;
using Shouldly;

namespace Application.IntegrationTests.Service;

public class CreateServiceCommandHandlerTest : BaseIntegrationTest
{
    public CreateServiceCommandHandlerTest(IntegrationTestWebAppFactory factory) 
        : base(factory)
    {
    }

    [Fact]
    public async Task Create_Should_ReturnError_WhenServiceAlreadyExists()
    {
        // arrange
        var post = await CreateTestPost();
        var command = new CreateServiceCommand()
        {
            AvailableDates = new List<DateOnly>()
            {
                DateOnly.FromDateTime(DateTime.Today),
                DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
                DateOnly.FromDateTime(DateTime.Today.AddDays(2)),
                DateOnly.FromDateTime(DateTime.Today.AddDays(3)),
            },
            MeetingPlaces = _faker.Random.Digits(3, 1, 3).ToHashSet(),
            PostId = post.Id,
            Price = _faker.Random.Int(1, 100),
            ServiceType = _faker.Random.Enum<ServiceType>()
        };
        // act
        await Sender.Send(command);
        var result = await Sender.Send(command);
        
        // assert
        result.Error.ShouldBe(ServiceErrors.ServiceAlreadyExists);

    }
    
    [Fact]
    public async Task Create_Should_ReturnSuccess_WhenServiceRequestIsValid()
    {
        // arrange
        var post = await CreateTestPost();
        var price = _faker.Random.Int(1, 100);
        var serviceType = _faker.Random.Enum<ServiceType>();
        var command = new CreateServiceCommand
        {
            AvailableDates = new List<DateOnly>
            {
                DateOnly.FromDateTime(DateTime.Today),
                DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
                DateOnly.FromDateTime(DateTime.Today.AddDays(2)),
                DateOnly.FromDateTime(DateTime.Today.AddDays(3))
            },
            MeetingPlaces = _faker.Random.Digits(3, 1, 3).ToHashSet(),
            PostId = post.Id,
            Price = price,
            ServiceType = serviceType
        };
        // act
        var result = await Sender.Send(command);
        
        // assert
        result.ShouldNotBeNull();
        result.Succeeded.ShouldBeTrue();
        
        var service = await DbContext
            .Services
            .Where(s => s.Name == serviceType.ToString() && 
                s.PostId == post.Id && 
                s.Price == price)
            .FirstOrDefaultAsync();
        
        service.ShouldNotBeNull();
        service.Price.ShouldBe(command.Price);
        service.MeetingPlaces.Count.ShouldBe(command.MeetingPlaces.Count);
        service.AvailableDates?.Count.ShouldBe(command.AvailableDates.Count);
        service.Name.ShouldBe(command.ServiceType.ToString());
    }
}