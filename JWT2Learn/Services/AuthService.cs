using Azure.Core;
using JWT2Learn.Entites;
using JWT2Learn.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWT2Learn.Services
{
    public class AuthService : IAuthService
    {
        DataCon con;
        IConfiguration config;
        public AuthService(DataCon con,IConfiguration config)
        {
            this.con = con;
            this.config = config;
        }
        public async Task<string> LoginAsync(UserDTO request)
        {
            var user = await con.Users.FirstOrDefaultAsync(o => o.Username == request.Username);
            if (user is null)
                return null;

            if (user.Username != request.Username || new PasswordHasher<User>()
             .VerifyHashedPassword(user, user.PasswordHash, request.Password) == PasswordVerificationResult.Failed)
                return null;

            string token = CreateToken(user);

            return "Hello you are logged in and this is your token  " + token;
        }

        public async Task<User> RegisterAsync(UserDTO request)
        {

            if(await con.Users.AnyAsync(o=>o.Username == request.Username))
                return null;

            var user = new User();

            var hashedpass = new PasswordHasher<User>()
                                    .HashPassword(user, request.Password);

            user.Username = request.Username;
            user.PasswordHash = hashedpass;

            await con.Users.AddAsync(user);
            await con.SaveChangesAsync();

            return user;
        }


        private string CreateToken(User user)
        {
            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokendescription = new JwtSecurityToken(
                    issuer: config.GetValue<string>("AppSettings:Issuer"),
                    audience: config.GetValue<string>("AppSettings:Audience"),
                    claims: Claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                    );

            return new JwtSecurityTokenHandler().WriteToken(tokendescription);
        }
    }
}
