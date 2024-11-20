using Zoolandia.Domain.Common;
using Zoolandia.Domain.Models;

namespace Zoolandia.Domain.Repositories;

public interface IProfileDomainRepository : IDomainRepository<Profile>
{
    Task<Profile> FindById(string profileId);
}