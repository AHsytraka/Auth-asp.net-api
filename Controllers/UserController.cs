using System.IdentityModel.Tokens.Jwt;
using Authentication_api.Repository;
using Authentication_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Authentication_api;

[ApiController]
[Route("[Controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly JwtService _jwtService;
    public UserController(IUserRepository userRepository, JwtService jwtService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    [HttpPost("Login")]
    public IActionResult Login(string email,string pwd)
    {
        try {

            var usr = _userRepository.GetUserByEmail(email);
            var jwt = _jwtService.Generator(usr.Uid, usr.Role);
            Response.Cookies.Append("jwt", jwt, new CookieOptions {
                HttpOnly = true
            });
            return Ok(new { message = "Success"});

        } catch(Exception)
        {
            return BadRequest(new { message = "An error occurred while processing your request" });
        }
    }

    [HttpGet("getUser")]
    [Authorize(Roles = "Admin")]
    public IActionResult GetUser()
    {
        try{
            var jwt = Request.Cookies["jwt"];
            // Parse the issuer from the JWT as an integer

            var token = _jwtService.Checker(jwt);
            if (token == null)
            {
                return Unauthorized(new { message = "Invalid token" });
            }
            int Uid = int.Parse(token.Issuer);
            var user = _userRepository.GetUserById(Uid);
            return Ok(user);
        }catch(Exception)
        {
            throw;
        }
    }

    [HttpPost("Logout")]
    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");
        return Ok( new {message = "success"});
    }
}
