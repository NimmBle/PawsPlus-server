using Zoolandia.Application.Common.Mapping;

namespace Zoolandia.Application.Features.Post.Queries.Search;

public class PostOutputModel : IMapFrom<Domain.Models.Post>
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string PhotoUrl { get; set; }
    
    public string Description { get; set; }
    
    public int ServicePrice { get; set; }

    // public void Mapping(AutoMapper.Profile mapper)
    //     => mapper
    //         .CreateMap<Domain.Models.Post, PostOutputModel>()
    //         .ForMember(dest => dest.FirstName, opts => opts.MapFrom(p => p.Profile.FirstName))
    //         .ForMember(dest => dest.LastName, opts => opts.MapFrom(p => p.Profile.LastName))
    //         .ForMember(dest => dest.PhotoUrl, opts => opts.MapFrom(p => p.Profile.PhotoUrl))
    //         .ForMember(dest => dest.Description, opts => opts.MapFrom(p => p.Profile.Description))
    //         .ForMember(dest => dest.ServicePrice, opts => opts.MapFrom((src, dest, destMember, context) =>
    //             src.Services.FirstOrDefault(s => s.Name == (string)context.Items["ServiceName"])?.Price ?? 0));

}