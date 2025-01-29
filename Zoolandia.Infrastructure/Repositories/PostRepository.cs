using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zoolandia.Application.Features.Post;
using Zoolandia.Application.Features.Post.Queries;
using Zoolandia.Application.Features.Post.Queries.Search;
using Zoolandia.Domain.Enums;
using Zoolandia.Domain.Models;
using Zoolandia.Domain.Repositories;
using Zoolandia.Infrastructure.Common.Persistence;

namespace Zoolandia.Infrastructure.Repositories;

public class PostRepository(
    ZoolandiaDbContext db,
    IMapper mapper)
    : DataRepository<ZoolandiaDbContext, Post>(db),
        IPostDomainRepository,
        IPostQueryRepository
{
    
    public async Task<Post> GetWithoutServices(string id, CancellationToken cancellationToken = default)
        => await All()
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    
    public async Task<Post> Get(string id, CancellationToken cancellationToken = default)
        => await All()
            .Where(p => p.Id == id)
            .Include(p => p.Services)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<PostDetailsOutputModel> GetDetails(string Id, CancellationToken cancellationToken = default)
        => mapper
            .Map<PostDetailsOutputModel>(await Get(Id));

    public async Task<PostDetailsOutputModel> GetDetailsByProfile(string profileId, CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<PostDetailsOutputModel>(this
                .All()
                .Where(p => p.ProfileId == profileId))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<IReadOnlyCollection<PostOutputModel>> Search(Expression<Func<Post, bool>> predicate,
        ServiceType serviceType,
        int skip,
        int take,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(predicate)
            .Select(p => new PostOutputModel
            {
                Id = p.ProfileId,
                FirstName = p.Profile.FirstName,
                LastName = p.Profile.LastName,
                PhotoUrl = p.Profile.PhotoUrl,
                Description = p.Profile.Description,
                ServicePrice = p.Services
                    .Where(s => s.Name == serviceType.ToString())
                    .Select(s => s.Price)
                    .FirstOrDefault()
            })
            .Skip(skip)
            .Take(take)
            .AsNoTracking()
            .ToListAsync(cancellationToken);
}