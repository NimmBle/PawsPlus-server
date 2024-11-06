using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Zoolandia.Server.Controllers;
using Zoolandia.Server.Data.Models;
using Zoolandia.Server.Features.Identity.Models;

namespace Zoolandia.Server.Features.Identity;

public class IdentityController : ApiController
{
    private readonly UserManager<User> _userManager;

    public IdentityController(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    
    [HttpPost]
    [Route(nameof(Register))]
    public async Task<ActionResult> Register(RegisterRequestModel model)
    {
        User user = new()
        {
            Email = model.Email,
            Profile = new()
            {
                FirstName = model.FirstName,
                LastName = model.LastName
            }
        };
        var result = await _userManager.CreateAsync(user, model.Password);

        if (result.Succeeded)
            return Ok();

        return BadRequest(result.Errors);

    }
}