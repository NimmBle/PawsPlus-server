using Microsoft.AspNetCore.Http;
using Zoolandia.Application.Common;
using Zoolandia.Application.Files.Commands.UploadImage;

namespace Zoolandia.Application.Files;

public interface IFile
{
    Task<Result<UploadImageOutputModel>> UploadImage(IFormFile image);
}