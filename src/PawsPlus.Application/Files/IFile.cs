using Microsoft.AspNetCore.Http;
using PawsPlus.Application.Common;
using PawsPlus.Application.Files.Commands.UploadImage;
using PawsPlus.Application.Files.Commands.UploadImages;

namespace PawsPlus.Application.Files;

public interface IFile
{
    Task<Result<UploadImageOutputModel>> UploadImage(IFormFile image);

    Task<Result<UploadImagesOutputModel>> UploadImages(IFormFileCollection images);
}