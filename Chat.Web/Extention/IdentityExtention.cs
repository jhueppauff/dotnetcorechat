using System.Linq;
using System.Security.Claims;

namespace dotnetcorechat.Extensions
{
    public static class IdentityExtension
    {
        public static string DisplayName(this ClaimsPrincipal user)
        {
            if (user.Identity.IsAuthenticated)
            {
                return user.Claims.FirstOrDefault(v => v.Type == ClaimTypes.GivenName).Value;
            }

            return "";
        }
    }
}