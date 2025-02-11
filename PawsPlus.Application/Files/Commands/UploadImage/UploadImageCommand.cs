using MediatR;
using Microsoft.AspNetCore.Http;
using PawsPlus.Application.Common;

namespace PawsPlus.Application.Files.Commands.UploadImage;

public class UploadImageCommand : IRequest<Result<UploadImageOutputModel>>
{
    public IFormFile Image { get; set; }
    
    public class UploadImageCommandHandler(IFile file)
        : IRequestHandler<UploadImageCommand, Result<UploadImageOutputModel>>
    {

        public async Task<Result<UploadImageOutputModel>> Handle(
            UploadImageCommand request,
            CancellationToken cancellationToken)
            => await file.UploadImage(request.Image);
    }
}