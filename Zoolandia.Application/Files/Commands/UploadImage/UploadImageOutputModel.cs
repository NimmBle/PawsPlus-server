namespace Zoolandia.Application.Files.Commands.UploadImage;

public class UploadImageOutputModel(string imageUrl)
{
    public string ImageUrl { get; } = imageUrl;
}