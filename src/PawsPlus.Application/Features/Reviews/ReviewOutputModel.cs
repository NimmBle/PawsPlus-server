using PawsPlus.Application.Common.Mapping;
using PawsPlus.Domain.Models;

namespace PawsPlus.Application.Features.Reviews;

public class ReviewOutputModel : IMapFrom<Review>
{
    public string PhotoUrl { get; set; }
    
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public double Rating { get; set; }
    
    public string Content { get; set; }
    
    public DateOnly ReviewDate { get; set; }

    public void Mapping(AutoMapper.Profile mapper)
        => mapper.CreateMap<Review, ReviewOutputModel>()
            .ForMember(dest => dest.PhotoUrl, src => src.MapFrom(src => src.Reviewer.PhotoUrl))
            .ForMember(dest => dest.FirstName, src => src.MapFrom(src => src.Reviewer.FirstName))
            .ForMember(dest => dest.LastName, src => src.MapFrom(src => src.Reviewer.LastName));
}