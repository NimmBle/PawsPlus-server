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
        IBreedDomainRepository,
        IBreedQueryRepository
{
    public async Task<IEnumerable<BreedOutputModel>> GetBreeds(string petType,
        CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<BreedOutputModel>(db
                .Breeds
                .Where(b => b.PetType.ToString() == petType))
            .ToListAsync(cancellationToken);

    public async Task<Breed> Find(int id,
        CancellationToken cancellationToken = default)
        => await All()
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
}