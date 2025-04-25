using MediatR;

namespace Application.IntegrationTests;

public class IdsOutputModel
{
    public IdsOutputModel(string userId, string profileId)
    {
        UserId = userId;
        ProfileId = profileId;
    }

    public string UserId { get; set; }
    public string ProfileId { get; set; }
    
    public IMediator sender { get; set; }
}