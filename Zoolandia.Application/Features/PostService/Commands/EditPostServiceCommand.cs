using MediatR;
using Zoolandia.Application.Common;
using Zoolandia.Domain.Repositories;

namespace Zoolandia.Application.Features.PostService.Commands;

public class EditPostServiceCommand : PostServiceInputModel, IRequest<Result>
{
        
    public class EditPostServiceCommandHandler(
        IPostServiceDomainRepository postServiceRepository)
        : IRequestHandler<EditPostServiceCommand, Result>
    {
        public async Task<Result> Handle(
            EditPostServiceCommand request,
            CancellationToken cancellationToken)
        {
            var postService = await postServiceRepository.GetById(request.Id);
            
            postService.Price = request.Price;
            postService.AvailableDates = request.AvailableDates;

            await postServiceRepository.Update(postService);

            return true;
        }
    }
}