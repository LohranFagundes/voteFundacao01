using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AppVote01.Authorization
{
    public class TimeLoginRequirement : AuthorizationHandler<TimeLoginRequirement>, IAuthorizationRequirement
    {

        private IConfiguration _configuration;

        public TimeLoginRequirement(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, TimeLoginRequirement requirement)
        {
            var filterContext = context.Resource as AuthorizationFilterContext;
            if (filterContext == null)
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var authorizationHeader = filterContext.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (string.IsNullOrEmpty(authorizationHeader))
            {
                context.Fail();
                return Task.CompletedTask;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = authorizationHeader.Split(' ').Last();

            try
            {
                tokenHandler.ValidateToken(tokenString, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(
                            // Substitua pela sua chave secreta JWT
                            _configuration["SymmetricSecurityKey"])
                     ),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var loginTimestampClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "loginTimestamp");
                if (loginTimestampClaim == null)
                {
                    context.Fail();
                    return Task.CompletedTask;
                }

                var loginTimestamp = DateTime.Parse(loginTimestampClaim.Value);
                if (DateTime.UtcNow > loginTimestamp.AddMinutes(3))
                {
                    context.Fail();
                    return Task.CompletedTask;
                }

                context.Succeed(requirement);
                return Task.CompletedTask;
            }
            catch (Exception)
            {
                context.Fail();
                return Task.CompletedTask;
            }
        }
    }
}