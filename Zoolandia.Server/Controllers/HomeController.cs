using Microsoft.AspNetCore.Mvc;

namespace Zoolandia.Server.Controllers;

public class HomeController : ApiController
{
    [HttpGet]
    public ActionResult<string> GetAll()
    {
        return Ok("works");
    }
}