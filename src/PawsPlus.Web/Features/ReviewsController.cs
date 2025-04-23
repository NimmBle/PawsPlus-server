using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawsPlus.Application.Features.Reviews.Commands.Create;
using PawsPlus.Application.Features.Reviews.Commands.Delete;

namespace PawsPlus.Web.Features;

public class ReviewsController : ApiController
{
    [HttpPost]
    [Authorize(Roles = "Owner")]
    public async Task<ActionResult> Create(CreateReviewCommand command)
        => await this.Send(command);

    [HttpDelete]
    [Authorize(Roles = "Owner")]
    public async Task<ActionResult> Delete(DeleteReviewCommand command)
        => await this.Send(command);
}