using Microsoft.EntityFrameworkCore;
using PawsPlus.Application.Features.Service.Commands.Edit;
using PawsPlus.Domain.Errors;
using Shouldly;

namespace Application.IntegrationTests.Service;

public class EditServiceCommandHandlerTest : BaseIntegrationTest
{
    public EditServiceCommandHandlerTest(IntegrationTestWebAppFactory factory) 
        : base(factory)
    {
    }

    [Fact]
    public async Task Edit_Should_ReturnError_WhenMeetingPlaceCountIsZero()
    {
        // arrange
        var service = await CreateTestService();

        var command = new EditServiceCommand
        {
            Id = service.Id,
            Price = _faker.Random.Int(1, 100),
            AvailableDates = new List<DateOnly>
            {
                DateOnly.FromDateTime(DateTime.Today),
                DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
                DateOnly.FromDateTime(DateTime.Today.AddDays(2)),
                DateOnly.FromDateTime(DateTime.Today.AddDays(3))
            },
            MeetingPlaces = _faker.Random.Digits(0, 1, 3).ToHashSet(),
        };
        
        // act
        var result = await Sender.Send(command, CancellationToken.None);
        
        // assert
        result.Error.ShouldBe(ServiceErrors.InvalidMeetingPlace);
    }
    
    [Fact]
    public async Task Edit_Should_ReturnSuccess_WhenRequestIsValid()
    {
        // arrange
        var service = await CreateTestService();

        var command = new EditServiceCommand
        {
            Id = service.Id,
            Price = _faker.Random.Int(1, 100),
            AvailableDates = new List<DateOnly>
            {
                DateOnly.FromDateTime(DateTime.Today),
                DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
                DateOnly.FromDateTime(DateTime.Today.AddDays(2)),
                DateOnly.FromDateTime(DateTime.Today.AddDays(3))
            },
            MeetingPlaces = _faker.Random.Digits(3, 1, 3).ToHashSet(),
        };
        
        // act
        var result = await Sender.Send(command, CancellationToken.None);
        
        // assert
        result.ShouldNotBeNull();
        result.Succeeded.ShouldBeTrue();
        
        var editedService = await DbContext.Services.FirstOrDefaultAsync(s => s.Id == service.Id);
        editedService.ShouldNotBeNull();
        editedService.Price.ShouldBe(command.Price);
        editedService.AvailableDates.Count.ShouldBe(command.AvailableDates.Count);
        editedService.MeetingPlaces.Count.ShouldBe(command.MeetingPlaces.Count);
    }
}