using NSubstitute;
using PawsPlus.Application.Features.Service.Commands.Create;
using PawsPlus.Domain.Enums;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;
using Shouldly;

namespace Application.UnitTests.Service.Commands;

public class CreateServiceCommandHandlerTest
{

    [Fact]
    public async Task CreateServiceCommandHandler_Should_ReturnSuccess_WhenRequestIsValid()
    {
        // Arrange
        DateOnly today = DateOnly.FromDateTime(DateTime.Now.AddDays(1));
        var command = new CreateServiceCommand
        {
            ServiceType = ServiceType.DogWalking,
            PostId = "1",
            Price = 10,
            AvailableDates = new List<DateOnly>()
            {
                today
            },
            MeetingPlaces = new HashSet<int>()
            {
                1
            },
        };
        var serviceDomainRepositoryMock = Substitute.For<IServiceDomainRepository>();
        var meetingPlaceDomainRepositoryMock = Substitute.For<IMeetingPlaceDomainRepository>();
        var dateDomainRepositoryMock = Substitute.For<IDateDomainRepository>();
        serviceDomainRepositoryMock.AlreadyExists(command.ServiceType.ToString(), default)
            .Returns(false);
        
        var count = command.AvailableDates.Count;
        dateDomainRepositoryMock.FindAll(command.AvailableDates[0], command.AvailableDates[count - 1])
            .Returns(new List<Date>()
            {
                new Date(today)
            });
        
        var handler = new CreateServiceCommand.CreateServiceCommandHandler(serviceDomainRepositoryMock,
            meetingPlaceDomainRepositoryMock,
            dateDomainRepositoryMock);
        
        // Act
        var result = await handler.Handle(command, CancellationToken.None);
        
        // Assert
        result.Succeeded.ShouldBeTrue();
    }
    
}