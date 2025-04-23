using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawsPlus.Application.Features.Breed.Queries;

namespace PawsPlus.Web.Features;

[Authorize(Roles = Owner)]
public class BreedsController : ApiController
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BreedOutputModel>>> Get(
        [FromQuery] GetBreedsQuery query)
        => await this.Send(query);
}