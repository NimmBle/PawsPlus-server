using Zoolandia.Application.Common.Mapping;
using Zoolandia.Application.Features.Service;
using Zoolandia.Domain.Enums.Pet;

namespace Zoolandia.Application.Features.Post.Queries;

public class PostDetailsOutputModel : IMapFrom<Domain.Models.Post>
{
    public string Id { get; set; }

    public ICollection<Weight> Weights { get; set; }

    public ICollection<PetType> Pets { get; set; }

    public List<ServiceOutputModel> Services { get; set; }

    public virtual void Mapping(AutoMapper.Profile mapper)
        => mapper
            .CreateMap<Domain.Models.Post, PostDetailsOutputModel>()
            .ForMember(dest => dest.Services, opt => opt.MapFrom(src => src.PostServices.Select(ps => new ServiceOutputModel()
                {
                    Id = ps.Id,
                    Name = ps.Service.Name,
                    Price = ps.Price
                })));
}