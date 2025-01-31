using Microsoft.AspNetCore.Mvc;
using APIILearn.Model;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using APIILearn.Authentication;
using System.Text;
using System.Security.Claims;
namespace APIILearn.Controllers
{                                   // primary ctor
    public class UsersController(JwtOptions jwtOp) : Controller
    {
        [HttpPost]
        [Route("auth")]
        public ActionResult<string> AuthenticateUser(Authentication_Request request)
        {
            var TokenHandler = new JwtSecurityTokenHandler();
            var TokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = jwtOp.Issuer,
                Audience = jwtOp.Audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOp.SigningKey)),
                SecurityAlgorithms.HmacSha256),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new(ClaimTypes.NameIdentifier, request.UserName),
                    new(ClaimTypes.Email,"a@b.com")
                })
            };
            var SecurityToken = TokenHandler.CreateToken(TokenDescriptor);
            var accessToken = TokenHandler.WriteToken(SecurityToken);

            return Ok(accessToken);
        }
    }
}
