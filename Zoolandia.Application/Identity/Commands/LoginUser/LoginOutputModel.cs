namespace Zoolandia.Application.Identity.Commands;

public class LoginOutputModel
{
    public LoginOutputModel(string userId, string token, bool firstLogin)
    {
        this.Id = userId;
        this.Token = token;
        this.FirstLogin = firstLogin;
    }
    public string Id { get; set; }
    
    public string Token { get; set; }
    
    public bool FirstLogin { get; set; }
}