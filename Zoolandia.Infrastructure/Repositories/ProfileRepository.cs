using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zoolandia.Application.Features.Profile;
using Zoolandia.Application.Features.Profile.Queries;
using Zoolandia.Application.Features.Profile.Queries.Mine;
using Zoolandia.Application.Features.Profile.Queries.Search;
using Zoolandia.Domain.Repositories;
using Zoolandia.Infrastructure.Common.Persistence;
using Zoolandia.Infrastructure.Identity;
using Profile = Zoolandia.Domain.Models.Profile;

namespace Zoolandia.Infrastructure.Repositories;

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
                    PlaceId = u.Profile.Location.PlaceId,
                                    
                })
                .FirstOrDefaultAsync(cancellationToken);
    
    public async Task<ProfileDetailsOutputModel> GetDetails(string profileId,
        CancellationToken cancellationToken = default)
        => await GetDetailsBase<ProfileDetailsOutputModel>(u => u.Profile.Id == profileId, cancellationToken);

    public async Task<MineProfileOutputModel> GetDetailsByUser(string userId,
        CancellationToken cancellationToken = default)
        => await GetDetailsBase<MineProfileOutputModel>(p => p.Id == userId, cancellationToken); 
    
}