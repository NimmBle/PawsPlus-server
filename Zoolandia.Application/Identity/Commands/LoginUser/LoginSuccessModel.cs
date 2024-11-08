namespace Zoolandia.Applicaiton.Identity.Commands.LoginUser;

public class LoginSuccessModel
{
    public LoginSuccessModel(string token)
    {
        this.Token = token;
    }
    public string Token { get; set; }
}