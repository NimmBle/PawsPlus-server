using PawsPlus.Domain.Common;
using PawsPlus.Domain.Models;

namespace PawsPlus.Domain.Repositories;

public interface IDeviceTokenDomainRepository 
    : IDomainRepository<DeviceToken>
{
    public Task<DeviceToken> Find(string id, CancellationToken cancellationToken = default);
    public Task<IReadOnlyList<string>> FindDeviceTokensByBookingId(string bookingId, CancellationToken cancellationToken = default);
    
    public Task<DeviceToken?> FindDeviceTokenByProfileId(string profileId, CancellationToken cancellationToken = default);
    
    public Task<bool> Delete(DeviceToken token, CancellationToken cancellationToken = default);

}