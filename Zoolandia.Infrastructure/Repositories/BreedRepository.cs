using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zoolandia.Application.Features.Breed;
using Zoolandia.Application.Features.Breed.Queries;
using Zoolandia.Domain.Models;
using Zoolandia.Domain.Repositories;
using Zoolandia.Infrastructure.Common.Persistence;

namespace Zoolandia.Infrastructure.Repositories;

public class BreedRepository(ZoolandiaDbContext db,
    IMapper mapper)
    : DataRepository<ZoolandiaDbContext, Breed>(db),
        IBreedQueryRepository,
        IBreedDomainRepository
{
    public async Task<IEnumerable<BreedOutputModel>> GetBreeds(string breedName,
        CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<BreedOutputModel>(db
                .Breeds
                .Where(b => b.Name.Contains(breedName)))
            .ToListAsync(cancellationToken);

}