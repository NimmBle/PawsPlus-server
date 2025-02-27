using PawsPlus.Application.Common.Mapping;
using PawsPlus.Application.Features.Service.Queries;
using PawsPlus.Domain.Models;

namespace PawsPlus.Application.Features.Post.Queries;

public class PostDetailsOutputModel : IMapFrom<Domain.Models.Post>
{
    public string Id { get; set; }

    public List<int> Weights { get; set; }

    public List<int> Pets { get; set; }
    
    public int Status { get; set; }

    public ICollection<ServiceOutputModel> Services { get; set; }

    public virtual void Mapping(AutoMapper.Profile mapper)
        => mapper
            .CreateMap<Domain.Models.Post, PostDetailsOutputModel>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Value))
            .ForMember(dest => dest.Weights, opt => opt.MapFrom(src => src.Weights.Select(w => w.Id).ToList()))
            .ForMember(dest => dest.Pets, opt => opt.MapFrom(p => p.Animals.Select(a => a.Id).ToList()));
}