using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zoolandia.Application.Files.Commands.UploadImage;
using Zoolandia.Application.Files.Commands.UploadImages;

namespace Zoolandia.Web.Features;

public class FilesController : ApiController
{
    [HttpPost]
    [Route(nameof(UploadImage))]
    public async Task<ActionResult<UploadImageOutputModel>> UploadImage(UploadImageCommand command)
        => await this.Send(command);
    
    [HttpPost]
    [Route(nameof(UploadImages))]
    public async Task<ActionResult<UploadImagesOutputModel>> UploadImages(UploadImagesCommand command)
        => await this.Send(command);
}