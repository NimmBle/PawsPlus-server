using PawsPlus.Domain.Common;
using PawsPlus.Domain.Models;

namespace PawsPlus.Domain.Repositories;

public interface IDeviceTokenDomainRepository 
    : IDomainRepository<DeviceToken>
{
    public Task<IReadOnlyList<string>> FindDeviceTokensByBookingId(string bookingId);
    
    public Task<IReadOnlyList<string>> FindDeviceTokenByProfileId(string profileId);

}