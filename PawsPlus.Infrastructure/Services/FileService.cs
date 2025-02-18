using System.Text.RegularExpressions;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using PawsPlus.Application.Common;
using PawsPlus.Application.Files;
using PawsPlus.Application.Files.Commands.UploadImage;
using PawsPlus.Application.Files.Commands.UploadImages;

namespace PawsPlus.Infrastructure.Services;

public class FileService(IOptions<ApplicationSettings> applicationSettings) : IFile
{
    private const string NoFileProvidedErrorMessage = "No file was uploaded";
    
    public async Task<Result<UploadImageOutputModel>> UploadImage(IFormFile image)
    {
        Cloudinary cloudinary = new(applicationSettings.Value.CloudinarySecret);

        if (image.Length == 0)
            return NoFileProvidedErrorMessage;

        var imageName = Regex.Replace(image.FileName, @"\s+", "");
        
        using var stream = new MemoryStream();
        await image.CopyToAsync(stream);
        stream.Position = 0; 
        
        var uploadParams = new ImageUploadParams
        {
            File = new FileDescription(imageName, stream),
            PublicId = imageName
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
            var imageName = Regex.Replace(image.FileName, @"\s+", "");
            
            using var stream = new MemoryStream();
            await image.CopyToAsync(stream);
            stream.Position = 0; 
        
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(imageName, stream),
                PublicId = imageName
            };

            var uploadResult = await cloudinary.UploadAsync(uploadParams);

            imageUrls.Add(uploadResult.SecureUrl.ToString());
        }

        return new UploadImagesOutputModel(imageUrls);
    }
}