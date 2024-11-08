namespace Zoolandia.Application.Identity.Commands.LoginUser;

public class LoginSuccessModel
{
    public LoginSuccessModel(string userId, string token)
    {
        Id = userId;
        Token = token;
    }
    
    public string Id { get; set; }
    public string Token { get; set; }
}