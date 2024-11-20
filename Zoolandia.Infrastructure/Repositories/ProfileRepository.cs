using Zoolandia.Application.Common;
using Zoolandia.Domain.Models;
using Zoolandia.Domain.Repositories;
using Zoolandia.Infrastructure.Common.Persistence;

namespace Zoolandia.Infrastructure.Repositories;

public class ProfileRepository(ZoolandiaDbContext db)
    : DataRepository<ZoolandiaDbContext, Profile>(db),
        IProfileDomainRepository
{
    public async Task<Profile> FindById(string profileId)
        => await Data
            .Profiles
            .FindAsync(profileId);
}