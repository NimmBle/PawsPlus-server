namespace Zoolandia.Application.Identity.Commands;

public class LoginOutputModel
{
    public LoginOutputModel(string userId, string token, bool firstLogin, IList<string> roles)
    {
        this.Id = userId;
        this.Token = token;
        this.FirstLogin = firstLogin;
        this.Roles = roles;
    }
    public string Id { get; set; }
    
    public string Token { get; set; }
    
    public bool FirstLogin { get; set; }
    
    public IList<string> Roles { get; set; } = new List<string>();
}