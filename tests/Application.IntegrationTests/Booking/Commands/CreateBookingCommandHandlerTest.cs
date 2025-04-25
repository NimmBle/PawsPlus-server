using Microsoft.EntityFrameworkCore;
using PawsPlus.Application.Features.Booking.Commands.Create;
using PawsPlus.Domain.Enums;
using PawsPlus.Domain.Errors;
using PawsPlus.Domain.Factories.Pet;
using PawsPlus.Domain.Models;
using Shouldly;

namespace Application.IntegrationTests.Booking.Commands;

public class CreateBookingCommandHandlerTest : BaseIntegrationTest
{
    public CreateBookingCommandHandlerTest(IntegrationTestWebAppFactory factory) 
        : base(factory)
    {
    }

    [Fact]
    public async Task Create_Should_ReturnError_WhenOwnerDoesNotHaveAPet()
    {
        // arrange
        var ids = await CreateTestUser();
        var sender = await ConfigureCurrentUser(ids.UserId, ids.ProfileId);
        var post = await CreateTestPost();
        var service = await CreateTestServiceFromPost(post.Id);
        var command = new CreateBookingCommand
        {
            AdditionalDescription = _faker.Lorem.Sentence(6),
            EndDay = DateOnly.FromDateTime(DateTime.Today.AddDays(3)),
            EndTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(2)),
            MeetingPlaceType = 2,
            SitterId = post.Profile.Id,
            ServiceType = (ServiceType)Enum.Parse(typeof(ServiceType), service.Name),
            StartDay = DateOnly.FromDateTime(DateTime.Today),
            StartTime = TimeOnly.FromDateTime(DateTime.Now)
        };
        
        // act
        var result = await sender.Send(command);
        
        // assert
        result.Error.ShouldBe(BookingErrors.OwnerPetIsNull);
    }
    
    [Fact]
    public async Task Create_Should_ReturnError_WhenServiceSitterIdIsWrong()
    {
        // arrange
        var ids = await CreateTestUser();
        var sender = await ConfigureCurrentUser(ids.UserId, ids.ProfileId);
        var pet = await CreatePetForUser(ids.ProfileId);
        var post = await CreateTestPost();
        var service = await CreateTestServiceFromPost(post.Id);
        var command = new CreateBookingCommand
        {
            AdditionalDescription = _faker.Lorem.Sentence(6),
            EndDay = DateOnly.FromDateTime(DateTime.Today.AddDays(3)),
            EndTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(2)),
            MeetingPlaceType = 2,
            SitterId = Guid.NewGuid().ToString(),
            ServiceType = (ServiceType)Enum.Parse(typeof(ServiceType), service.Name),
            StartDay = DateOnly.FromDateTime(DateTime.Today),
            StartTime = TimeOnly.FromDateTime(DateTime.Now)
        };
        
        // act
        var result = await sender.Send(command);
        
        // assert
        result.Error.ShouldBe(ServiceErrors.ServiceNotFound);
    }
    
    [Fact]
    public async Task Create_Should_ReturnError_WhenServiceTypeIsWrong()
    {
        // arrange
        var ids = await CreateTestUser();
        var sender = await ConfigureCurrentUser(ids.UserId, ids.ProfileId);
        var pet = await CreatePetForUser(ids.ProfileId);
        var post = await CreateTestPost();
        var service = await CreateTestServiceFromPost(post.Id);
        var command = new CreateBookingCommand
        {
            AdditionalDescription = _faker.Lorem.Sentence(6),
            EndDay = DateOnly.FromDateTime(DateTime.Today.AddDays(3)),
            EndTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(2)),
            MeetingPlaceType = 2,
            SitterId = post.Profile.Id,
            ServiceType = _faker.Random.Enum<ServiceType>((ServiceType)Enum.Parse(typeof(ServiceType), service.Name)),
            StartDay = DateOnly.FromDateTime(DateTime.Today),
            StartTime = TimeOnly.FromDateTime(DateTime.Now)
        };
        
        // act
        var result = await sender.Send(command);
        
        // assert
        result.Error.ShouldBe(ServiceErrors.ServiceNotFound);
    }
    
    [Fact]
    public async Task Create_Should_ReturnSuccess_WhenRequestIsValid()
    {
        // arrange
        var ids = await CreateTestUser();
        var sender = await ConfigureCurrentUser(ids.UserId, ids.ProfileId);
        var pet = await CreatePetForUser(ids.ProfileId);
        var post = await CreateTestPost();
        var service = await CreateTestServiceFromPost(post.Id);
        var command = new CreateBookingCommand
        {
            AdditionalDescription = _faker.Lorem.Sentence(6),
            EndDay = DateOnly.FromDateTime(DateTime.Today.AddDays(3)),
            EndTime = TimeOnly.FromDateTime(DateTime.Now.AddHours(2)),
            MeetingPlaceType = 2,
            SitterId = post.Profile.Id,
            ServiceType = (ServiceType)Enum.Parse(typeof(ServiceType), service.Name),
            StartDay = DateOnly.FromDateTime(DateTime.Today),
            StartTime = TimeOnly.FromDateTime(DateTime.Now)
        };
        
        // act
        var result = await sender.Send(command);
        
        // assert
        result.Succeeded.ShouldBeTrue();

        var booking = await DbContext.Bookings.FirstOrDefaultAsync(b => b.Id == result.Data);
        booking.ShouldNotBeNull();
        booking.StartDay.ShouldBe(command.StartDay);
        booking.StartTime.ShouldBe(command.StartTime);
        booking.EndDay.ShouldBe(command.EndDay);
        booking.EndTime.ShouldBe(command.EndTime);
        booking.ServiceId.ShouldBe(service.Id);
        booking.Status.ShouldBe(BookingState.Pending);
        booking.AdditionalDescription.ShouldBe(command.AdditionalDescription);

    }
}