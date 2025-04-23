using Microsoft.AspNetCore.Mvc;
using PawsPlus.Application.Files.Commands.UploadImage;
using PawsPlus.Application.Files.Commands.UploadImages;

namespace PawsPlus.Web.Features;

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