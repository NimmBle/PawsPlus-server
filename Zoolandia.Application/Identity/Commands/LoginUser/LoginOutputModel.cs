namespace Zoolandia.Application.Identity.Commands;

public class LoginOutputModel
{
    public LoginOutputModel(string userId, string token)
    {
        this.Id = userId;
        this.Token = token;
    }
    public string Id { get; set; }
    
    public string Token { get; set; }
}