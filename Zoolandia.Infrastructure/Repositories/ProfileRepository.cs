using Microsoft.EntityFrameworkCore;
using Zoolandia.Application.Features.Profile.Commands;
using Zoolandia.Domain.Models;
using Zoolandia.Domain.Repositories;
using Zoolandia.Infrastructure.Common.Persistence;

namespace Zoolandia.Infrastructure.Repositories;

public class ProfileRepository(ZoolandiaDbContext db)
    : DataRepository<ZoolandiaDbContext, Profile>(db),
        IProfileDomainRepository
{
    public async Task<Profile> FindByUser(string userId)
        => await this
            .Data
            .Users
            .Where(u => u.Id == userId)
            .Select(u => u.Profile)
            .FirstOrDefaultAsync();
}