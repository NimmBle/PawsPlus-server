using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public async Task<Profile> FindByUser(string userId)
        => await this
            .Data
            .Users
            .Where(u => u.Id == userId)
            .Select(u => u.Profile)
            .FirstOrDefaultAsync();

    public async Task<ProfileDetailsOutputModel> UserDetails(string userId, CancellationToken cancellationToken)
        => await mapper
            .ProjectTo<ProfileDetailsOutputModel>(this
                .All()
                .Where(u => u.Id == userId))
            .FirstOrDefaultAsync(cancellationToken);
}