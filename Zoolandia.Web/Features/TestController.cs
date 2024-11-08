using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Zoolandia.Web.Features;


public class TestController : ApiController
{
    [HttpGet]
    [Authorize]
    public async Task<ActionResult> GetAll()
    {
        return Ok("here are all the users");
    }
}