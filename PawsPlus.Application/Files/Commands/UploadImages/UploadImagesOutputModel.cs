namespace PawsPlus.Application.Files.Commands.UploadImages;

public class UploadImagesOutputModel(List<string> imageUrls)
{
    public List<string> ImageUrls { get; } = imageUrls;
}