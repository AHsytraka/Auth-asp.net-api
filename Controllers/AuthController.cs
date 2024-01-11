using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Mvc;

namespace Auth_Jwt.Controllers;

[ApiController]
[Route("[Controller]")]
public class AuthController : ControllerBase
{
    //redirect to the google authentication page : https://localhost:7086/auth/login
    [HttpGet("login")]
    public IActionResult Login()
    {
        var props = new AuthenticationProperties { RedirectUri = "account/signin-google"};
        return Challenge(props, GoogleDefaults.AuthenticationScheme);
    }

    [HttpGet("signin-google")]
    public async Task<IActionResult> GoogleLogin()
    {
        var response = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if(response.Principal == null) return BadRequest();

        //Use the user's data
        //For Login usage : Assign a token
        var name = response.Principal.FindFirstValue(ClaimTypes.Name);
        var givenName = response.Principal.FindFirstValue(ClaimTypes.GivenName);
        var email = response.Principal.FindFirstValue(ClaimTypes.Email);
        string user = $"{name}, {givenName}, {email}";
        return Ok(user);
    }
}
