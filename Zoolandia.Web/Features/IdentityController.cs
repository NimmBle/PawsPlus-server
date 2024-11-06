using Microsoft.AspNetCore.Mvc;

namespace Zoolandia.Web.Features;

public class IdentityController : ApiController
{
    // private readonly UserManager<User> _userManager;
    //
    // public IdentityController(UserManager<User> userManager)
    // {
    //     _userManager = userManager;
    // }
    
    [HttpPost]
    [Route(nameof(Register))]
    public async Task<ActionResult> Register()
    {
        // User user = new()
        // {
        //     Email = model.Email,
        //     UserName = model.Email,
        //     Profile = new()
        //     {
        //         FirstName = model.FirstName,
        //         LastName = model.LastName
        //     }
        // };
        // var result = await _userManager.CreateAsync(user, model.Password);
        //
        // if (result.Succeeded)
        //     return Ok();
        //
        // return BadRequest(result.Errors);
        return Ok();
    }
}