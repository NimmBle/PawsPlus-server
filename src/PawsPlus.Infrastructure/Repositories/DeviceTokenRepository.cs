using Microsoft.EntityFrameworkCore;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;
using PawsPlus.Infrastructure.Common.Persistence;

namespace PawsPlus.Infrastructure.Repositories;

public class DeviceTokenRepository(PawsPlusDbContext db)
    : DataRepository<PawsPlusDbContext, DeviceToken>(db),
        IDeviceTokenDomainRepository
{
    public async Task<IReadOnlyList<string>> FindDeviceTokensByBookingId(string bookingId)
        => await this
            .All()
            .Where(dt => dt.BookingId == bookingId)
            .Select(dt => dt.Token)
            .ToListAsync();

    public async Task<IReadOnlyList<string>> FindDeviceTokenByProfileId(string profileId)
        => await this 
            .All()
            .Distinct()
            .Where(dt => dt.ProfileId == profileId)
            .Select(dt => dt.Token)
            .ToListAsync();
}