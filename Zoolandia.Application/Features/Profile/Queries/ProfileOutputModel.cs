using Zoolandia.Application.Common.Mapping;

namespace Zoolandia.Application.Features.Profile.Queries;

public class ProfileOutputModel : IMapFrom<Domain.Models.Profile>
{   
    
    public string Id { get; set; }
    
    public string Email { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string PhoneNumber { get; set; }
    
    public string Description { get; set; }

    public string PhotoUrl { get; set; } = "https://res.cloudinary.com/ds95qikmm/image/upload/v1732147641/happy-man-sitting-with-three-cats-armchair-cartoon 1.svg.svg";
    
    public string PlaceId { get; set; }
    
    public IList<string>? Roles { get; set; } = new List<string>();
    
}