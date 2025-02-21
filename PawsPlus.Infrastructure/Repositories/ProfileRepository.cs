using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PawsPlus.Application.Features.Profile;
using PawsPlus.Application.Features.Profile.Queries;
using PawsPlus.Application.Features.Profile.Queries.Mine;
using PawsPlus.Application.Features.Profile.Queries.Search;
using PawsPlus.Domain.Repositories;
using PawsPlus.Infrastructure.Common.Persistence;
using PawsPlus.Infrastructure.Identity;
using Profile = PawsPlus.Domain.Models.Profile;

namespace PawsPlus.Infrastructure.Repositories;

public class ProfileRepository(
    ZoolandiaDbContext db)
    : DataRepository<ZoolandiaDbContext, Profile>(db),
        IProfileDomainRepository,
        IProfileQueryRepository
{
    public async Task<Profile> Find(string profileId,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(p => p.Id == profileId)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<Profile> FindByUser(string userId,
        CancellationToken cancellationToken = default)
        => await this
            .Data
            .Users
            .Where(u => u.Id == userId)
            .Select(u => u.Profile)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<T> GetDetailsBase<T>(Expression<Func<User, bool>> predicate,
        CancellationToken cancellationToken = default)
        where T : ProfileOutputModel, new()
        => await this
                .Data
                .Users
                .Where(predicate)
                .Select(u => new T()
                {
                    Id = u.Profile.Id,
                    FirstName = u.Profile.FirstName,
                    LastName = u.Profile.LastName,
                    Description = u.Profile.Description,
                    Email = u.Email,
                    PhoneNumber = u.Profile.PhoneNumber,
                    PhotoUrl = u.Profile.PhotoUrl,
                    Location = new LocationOutputModel()
                    {
                        PlaceId = u.Profile.Location.PlaceId 
                    }
                })
                .FirstOrDefaultAsync(cancellationToken);
    
    public async Task<ProfileDetailsOutputModel> GetDetails(string profileId,
        CancellationToken cancellationToken = default)
        => await GetDetailsBase<ProfileDetailsOutputModel>(u => u.Profile.Id == profileId, cancellationToken);

    public async Task<MineProfileOutputModel> GetDetailsByUser(string userId,
        CancellationToken cancellationToken = default)
        => await GetDetailsBase<MineProfileOutputModel>(p => p.Id == userId, cancellationToken);

    public async Task<string> GetProfileIdByUser(string userId, CancellationToken cancellationToken = default)
        => await this
            .Data
            .Users
            .Where(u => u.Id == userId)
            .Select(u => u.Profile.Id)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<string> GetUserIdByProfileId(string profileId, CancellationToken cancellationToken = default)
        => await this
            .Data
            .Users
            .Where(u => u.Profile.Id == profileId)
            .Select(u => u.Id)
            .FirstOrDefaultAsync(cancellationToken);
}