using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Zoolandia.Application.Common;
using Zoolandia.Application.Files;
using Zoolandia.Application.Files.Commands.UploadImage;
using Zoolandia.Application.Files.Commands.UploadImages;

namespace Zoolandia.Infrastructure.Files;

public class FileService(IOptions<ApplicationSettings> applicationSettings) : IFile
{
    private const string NoFileProvidedErrorMessage = "No file was uploaded";
    
    public async Task<Result<UploadImageOutputModel>> UploadImage(IFormFile image)
    {
        Cloudinary cloudinary = new(applicationSettings.Value.CloudinarySecret);

        if (image.Length == 0)
            return NoFileProvidedErrorMessage;

        using var stream = new MemoryStream();
        await image.CopyToAsync(stream);
        stream.Position = 0; 
        
        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(image.FileName, stream),
            PublicId = image.FileName
        };

        var uploadResult = await cloudinary.UploadAsync(uploadParams);

        var imageUrl = uploadResult.SecureUrl.ToString();

        return new UploadImageOutputModel(imageUrl);
    }

    public async Task<Result<UploadImagesOutputModel>> UploadImages(IFormFileCollection images)
    {
        Cloudinary cloudinary = new(applicationSettings.Value.CloudinarySecret);

        if (images.Count == 0)
            return NoFileProvidedErrorMessage;

        var imageUrls = new List<string>();

        foreach (var image in images)
        {
            using var stream = new MemoryStream();
            await image.CopyToAsync(stream);
            stream.Position = 0; 
        
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(image.FileName, stream),
                PublicId = image.FileName
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            imageUrls.Add(uploadResult.SecureUrl.ToString());
        }

        return new UploadImagesOutputModel(imageUrls);
    }
}