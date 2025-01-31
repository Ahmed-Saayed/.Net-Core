using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace APIILearn.Authentication
{
    public class Basic_Authentication_Handler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public Basic_Authentication_Handler(IOptionsMonitor<AuthenticationSchemeOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return Task.FromResult(AuthenticateResult.NoResult());

            var authoHearder = Request.Headers["Authorization"].ToString();
            if (!authoHearder.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase))
                return Task.FromResult(AuthenticateResult.Fail("Unknown scheme"));

            var encoded = authoHearder["Basic ".Length..];
            var decoded = Encoding.UTF8.GetString(Convert.FromBase64String(encoded));
            var userNameAndPass = decoded.Split(':');

            if (userNameAndPass[0] != "admin" || userNameAndPass[1]!= "password")
                return Task.FromResult(AuthenticateResult.Fail("Invalid UserName or Password"));

            var Identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier,"1"),
                new Claim(ClaimTypes.Name,userNameAndPass[0])
            }, "Basic");

            var principal = new ClaimsPrincipal(Identity);
            var ticket = new AuthenticationTicket(principal, "Basic");

            return Task.FromResult(AuthenticateResult.Success(ticket));
        }
    }
}
