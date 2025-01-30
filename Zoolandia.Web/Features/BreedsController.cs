using Microsoft.AspNetCore.Mvc;
using Zoolandia.Application.Features.Breed.Queries;

namespace Zoolandia.Web.Features;

public class BreedsController : ApiController
{

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BreedOutputModel>>> Get(
        [FromQuery] GetBreedsQuery query)
        => await this.Send(query);
}