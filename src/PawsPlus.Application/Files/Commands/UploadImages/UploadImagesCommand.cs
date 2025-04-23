using MediatR;
using Microsoft.AspNetCore.Http;
using PawsPlus.Application.Common;

namespace PawsPlus.Application.Files.Commands.UploadImages;

public class UploadImagesCommand : IRequest<Result<UploadImagesOutputModel>>
{
    public IFormFileCollection Images { get; set; }
    
    class UploadImagesCommandHandler(IFile file)
        : IRequestHandler<UploadImagesCommand, Result<UploadImagesOutputModel>>
    {
        public async Task<Result<UploadImagesOutputModel>> Handle(UploadImagesCommand request,
            CancellationToken cancellationToken)
            => await file.UploadImages(request.Images);
    }
}