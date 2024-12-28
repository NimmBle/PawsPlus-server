using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Zoolandia.Application.Features.Post;
using Zoolandia.Application.Features.Post.Queries;
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
    public async Task<PostDetailsOutputModel> PostDetails(string profileId)
        => await mapper
            .ProjectTo<PostDetailsOutputModel>(this
                .All()
                .Include(p => p.PostServices)
                .Where(p => p.ProfileId == profileId))
            .FirstOrDefaultAsync();
}