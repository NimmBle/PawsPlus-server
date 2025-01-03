namespace Zoolandia.Application.Identity.Commands.LoginUser;

public class LoginSuccessModel
{
    public LoginSuccessModel(string userId, string token, bool firstLogin = false)
    {
        this.Id = userId;
        this.Token = token;
        this.FirstLogin = firstLogin;
    }
    
    public string Id { get; set; }
    public string Token { get; set; }
    
    public bool FirstLogin { get; set; }
}