using Zoolandia.Application.Common.Mapping;
using Zoolandia.Application.Features.Service;
using Zoolandia.Domain.Enums.Pet;

namespace Zoolandia.Application.Features.Post.Queries;

public class PostDetailsOutputModel : IMapFrom<Domain.Models.Post>
{
    public string Id { get; set; }

    public HashSet<Weight> Weights { get; set; }

    public HashSet<PetType> Pets { get; set; }

    public ICollection<ServiceOutputModel> Services { get; set; }

    public virtual void Mapping(AutoMapper.Profile mapper)
        => mapper
            .CreateMap<Domain.Models.Post, PostDetailsOutputModel>()
            .ForMember(dest => dest.Pets, opt => opt.MapFrom(p => p.PetTypes));
}