using AutoMapper;
using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Application.Features.Service.Commands.Create;
using Zoolandia.Domain.Enums;
using Zoolandia.Domain.Enums.Pet;
using Zoolandia.Domain.Repositories;

namespace Zoolandia.Application.Features.Post.Commands.Create;

public class CreatePostCommand : IRequest<Result>
{
    public ICollection<PetType> Pets { get; set; }
    public ICollection<Weight>? Weights { get; set; }
    public ICollection<ServiceType> Services { get; set; }
    public string profileId { get; set; }
    
    public class CreatePostCommandHandler(
        IPostDomainRepository postRepository,
        IServiceDomainRepository serviceRepository)
        : IRequestHandler<CreatePostCommand, Result>
    {
        public async Task<Result> Handle(
            CreatePostCommand request,
            CancellationToken cancellationToken)
        {
            var post = new Domain.Models.Post
            {
                Id = Guid.NewGuid().ToString(),
                Pets = request.Pets,
                Weights = request.Weights,
                ProfileId = request.profileId,
                Status = PostStatus.Unscheduled
            };
            
            foreach (var service in request.Services)
            {
                var serviceModel = new Domain.Models.Service
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = service.ToString()
                };
                post.Services.Add(serviceModel);
            }
            
            await postRepository.Save(post, cancellationToken);

            return true;
        }
    }
}