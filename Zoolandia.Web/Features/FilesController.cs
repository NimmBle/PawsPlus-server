using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Zoolandia.Application.Files.Commands.UploadImage;

namespace Zoolandia.Web.Features;

public class FilesController : ApiController
{
    [HttpPost]
    [Route(nameof(UploadImage))]
    public async Task<ActionResult<UploadImageOutputModel>> UploadImage(UploadImageCommand command)
        => await this.Send(command);
}