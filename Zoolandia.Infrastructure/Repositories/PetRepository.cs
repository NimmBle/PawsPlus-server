using Zoolandia.Domain.Models;
using Zoolandia.Domain.Repositories;
using Zoolandia.Infrastructure.Common.Persistence;

namespace Zoolandia.Infrastructure.Repositories;

public class PetRepository
    (ZoolandiaDbContext db)
        : DataRepository<ZoolandiaDbContext, Pet>(db),
            IPetDomainRepository
{
    
}