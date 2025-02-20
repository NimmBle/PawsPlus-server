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
    public async Task<IEnumerable<BreedOutputModel>> GetBreeds(int animalTypeId,
        CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<BreedOutputModel>(this
                .All()
                .Where(b => b.AnimalType.Id == animalTypeId))
            .ToListAsync(cancellationToken);

    public async Task<Breed> Find(string id,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);

    public async Task<List<Breed>> FindAll(IEnumerable<string> ids, CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(at => ids.Contains(at.Id))
            .ToListAsync(cancellationToken);
}