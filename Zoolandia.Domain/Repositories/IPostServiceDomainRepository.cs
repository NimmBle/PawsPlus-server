using Zoolandia.Domain.Common;
using Zoolandia.Domain.Models;

namespace Zoolandia.Domain.Repositories;

public interface IPostServiceDomainRepository : IDomainRepository<PostService>
{
    Task<PostService> GetById(string postServiceId);
}