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
    public async Task<PostDetailsOutputModel> GetPostDetails(string Id)
        => await mapper
            .ProjectTo<PostDetailsOutputModel>(this
                .All()
                .Where(p => p.Id == Id))
            .FirstOrDefaultAsync();

    public async Task<PostDetailsOutputModel> GetPostDetailsByProfile(string profileId)
        => await mapper
            .ProjectTo<PostDetailsOutputModel>(this
                .All()
                .Where(p => p.ProfileId == profileId))
            .FirstOrDefaultAsync();
}