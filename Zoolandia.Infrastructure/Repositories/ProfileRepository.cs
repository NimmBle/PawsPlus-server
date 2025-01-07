using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zoolandia.Application.Features.Profile;
using Zoolandia.Application.Features.Profile.Queries;
using Zoolandia.Domain.Repositories;
using Zoolandia.Infrastructure.Common.Persistence;
using Profile = Zoolandia.Domain.Models.Profile;

namespace Zoolandia.Infrastructure.Repositories;

public class ProfileRepository(
    ZoolandiaDbContext db,
    IMapper mapper)
    : DataRepository<ZoolandiaDbContext, Profile>(db),
        IProfileDomainRepository,
        IProfileQueryRepository
{
    public async Task<Profile> Find(string profileId)
        => await this
            .All()
            .Where(p => p.Id == profileId)
            .FirstOrDefaultAsync();

    public async Task<Profile> FindByUser(string userId)
        => await this
            .Data
            .Users
            .Where(u => u.Id == userId)
            .Select(u => u.Profile)
            .FirstOrDefaultAsync();

    public async Task<string> GetProfileId(string userId, CancellationToken cancellationToken = default)
        => await this
            .Data
            .Users
            .Where(u => u.Id == userId)
            .Select(u => u.Profile!.Id)
            .FirstOrDefaultAsync();

    public async Task<ProfileDetailsOutputModel> GetDetails(string profileId, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<ProfileDetailsOutputModel>(this
                .All()
                .Where(u => u.Id == profileId))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<ProfileDetailsOutputModel> GetDetailsByUser(string userId, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<ProfileDetailsOutputModel>(this
                .Data
                .Users
                .Where(u => u.Id == userId)
                .Select(u => u.Profile))
            .FirstOrDefaultAsync();

    public async Task<string> GetEmailByUser(string userId, CancellationToken cancellationToken = default)
        => await this
            .Data
            .Users
            .Where(u => u.Id == userId)
            .Select(u => u.Email)
            .FirstOrDefaultAsync();
}