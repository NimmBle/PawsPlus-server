using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zoolandia.Application.Features.Breed;
using Zoolandia.Application.Features.Breed.Queries;
using Zoolandia.Domain.Enums.Pet;
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
    public async Task<IEnumerable<BreedOutputModel>> GetBreeds(PetType petType,
        CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<BreedOutputModel>(this
                .All()
                .Where(b => b.PetType == petType))
            .ToListAsync(cancellationToken);

    public async Task<Breed> Find(string id,
        CancellationToken cancellationToken = default)
        => await All()
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
}