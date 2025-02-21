using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PawsPlus.Application.Features.Post;
using PawsPlus.Application.Features.Post.Queries;
using PawsPlus.Application.Features.Post.Queries.Search;
using PawsPlus.Domain.Enums;
using PawsPlus.Domain.Models;
using PawsPlus.Domain.Repositories;
using PawsPlus.Infrastructure.Common.Persistence;

namespace PawsPlus.Infrastructure.Repositories;

public class PostRepository(
    ZoolandiaDbContext db,
    IMapper mapper)
    : DataRepository<ZoolandiaDbContext, Post>(db),
        IPostDomainRepository,
        IPostQueryRepository
{
    
    public async Task<Post> Find(string id,
        CancellationToken cancellationToken = default)
        => await All()
            .Where(p => p.Id == id)
            .Include(p => p.Services)
            .Include(p => p.AnimalTypes)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<bool> Delete(string id,
        CancellationToken cancellationToken = default)
    {
        var post = await this.Find(id);

        if (post == null)
            return false;
        
        this.Data.Posts.Remove(post);
        
        await this.Data.SaveChangesAsync(cancellationToken);

        return true;
    }

    public async Task<PostDetailsOutputModel> GetDetails(string Id,
        CancellationToken cancellationToken = default)
        => mapper
            .Map<PostDetailsOutputModel>(await Find(Id, cancellationToken));

    public async Task<PostDetailsOutputModel> GetDetailsByProfile(string profileId,
        CancellationToken cancellationToken = default)
        => await mapper
            .ProjectTo<PostDetailsOutputModel>(this
                .All()
                .Where(p => p.ProfileId == profileId)
                .Include(p => p.AnimalTypes))
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<IReadOnlyCollection<PostOutputModel>> Search(Expression<Func<Post, bool>> predicate,
        Expression<Func<Post, object>> orderBy,
        ServiceType serviceType,
        int skip,
        int take,
        CancellationToken cancellationToken = default)
        => await this
            .All()
            .Where(predicate)
            .OrderByDescending(orderBy)
            .Include(p => p.AnimalTypes)
            .Select(p => new PostOutputModel
            {
                Id = p.ProfileId,
                FirstName = p.Profile.FirstName,
                LastName = p.Profile.LastName,
                PhotoUrl = p.Profile.PhotoUrl,
                Description = p.Profile.Description,
                PlaceId = p.Profile.Location.PlaceId,
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