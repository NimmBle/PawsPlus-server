namespace Zoolandia.Application.Common;

public class ApplicationSettings
{
    public ApplicationSettings()
    {
        this.Secret = "default!";
        this.CloudinarySecret = default!;
    }
    
    public string Secret { get; private set; }

    public string CloudinarySecret { get; private set; }
}