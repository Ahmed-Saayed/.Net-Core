using JWT2Learn.Entites;
using JWT2Learn.Models;
using JWT2Learn.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT2Learn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService auth) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<ActionResult<User>>Register(UserDTO request)
        {
            var user = await auth.RegisterAsync(request);

            if (user is null)
                return BadRequest("User already exists");

            return Ok(user); 
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(UserDTO request)
        {
            var user = await auth.LoginAsync(request);

            if(user is null)
                return BadRequest("Invalid UserName or Password");

            return Ok(user);
        }

        [Authorize]
        [HttpGet("Check_if_I_authorized_to_access_this_function")]
        public ActionResult Ceck_Authorized()
        {
            return Ok("You are authorized to access this function and back to min 53 for this <3");
        }

        [Authorize(Roles ="Admin")]
        [HttpGet("Ceck_Admin_Authorized")]
        public ActionResult Ceck_Admin_Authorized()
        {
            return Ok("You are Admin welcome sir ");
        }
    }
}
