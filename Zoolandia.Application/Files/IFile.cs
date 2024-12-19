using Microsoft.AspNetCore.Http;
using Zoolandia.Application.Common;
using Zoolandia.Application.Files.Commands.UploadImage;
using Zoolandia.Application.Files.Commands.UploadImages;

namespace Zoolandia.Application.Files;

public interface IFile
{
    Task<Result<UploadImageOutputModel>> UploadImage(IFormFile image);

    Task<Result<UploadImagesOutputModel>> UploadImages(IFormFileCollection images);
}