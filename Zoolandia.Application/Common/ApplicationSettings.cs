namespace Zoolandia.Application.Common;

public class ApplicationSettings
{
    public ApplicationSettings()
    {
        this.Secret = "S0M3 M4G1C UN1C0RNS G3N3R4T3D TH1S S3CR3T";
        this.CloudinarySecret = default!;
    }
    
    public string Secret { get; private set; }

    public string CloudinarySecret { get; private set; }
}