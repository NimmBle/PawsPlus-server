using Microsoft.EntityFrameworkCore;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;
using PawsPlus.Infrastructure.Common.Persistence;

namespace PawsPlus.Infrastructure.Repositories;

public class DeviceTokenRepository(PawsPlusDbContext db)
    : DataRepository<PawsPlusDbContext, DeviceToken>(db),
        IDeviceTokenDomainRepository
{
    public async Task<DeviceToken> Find(string id, CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(dt => dt.Id == id, cancellationToken);
    
    public async Task<DeviceToken?> FindDeviceTokenByProfileId(string profileId, CancellationToken cancellationToken = default)
        => await this 
            .All()
            .Where(dt => dt.ProfileId == profileId)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<bool> Delete(DeviceToken token, CancellationToken cancellationToken = default)
    {
        this.Data.DeviceTokens.Remove(token);

        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }
}