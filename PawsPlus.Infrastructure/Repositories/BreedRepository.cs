using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawsPlus.Application.Features.Breed;
using PawsPlus.Application.Features.Breed.Queries;
using PawsPlus.Domain.Enums.Pet;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;
using PawsPlus.Infrastructure.Common.Persistence;

namespace PawsPlus.Infrastructure.Repositories;

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