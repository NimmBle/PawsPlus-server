using PawsPlus.Application.Common.Mapping;
using PawsPlus.Application.Features.Post.Queries;
using PawsPlus.Application.Features.Reviews;

namespace PawsPlus.Application.Features.Profile.Queries.Details;

public class ProfileDetailsOutputModel : IMapFrom<Domain.Models.Profile>
{
    public string Id { get; set; }
    
    public string? Email { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }
    
    public string Description { get; set; }

    public string PhotoUrl { get; set; } = "https://res.cloudinary.com/ds95qikmm/image/upload/v1732147641/happy-man-sitting-with-three-cats-armchair-cartoon 1.svg.svg";
    
    public LocationOutputModel Location { get; set; }

    public ICollection<ReviewOutputModel>? Reviews { get; set; } = new List<ReviewOutputModel>();
    
    public PostDetailsOutputModel? Post { get; set; }

    public void Mapping(AutoMapper.Profile mapper)
        => mapper
            .CreateMap<Domain.Models.Profile, ProfileDetailsOutputModel>();
}