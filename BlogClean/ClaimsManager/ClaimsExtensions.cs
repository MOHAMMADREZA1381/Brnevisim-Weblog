using System.Security.Claims;

namespace BlogClean.ClaimsManager
{
    public static class ClaimsExtensions
    {
        public static int GetCurrentUserId(this ClaimsPrincipal principal)
        {
            return Convert.ToInt32(principal.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);
        }

        public static string GetCurrentUserEmail(this ClaimsPrincipal principal)
        {
            return principal.Claims.Single(c => c.Type == ClaimTypes.Email).Value;
        }
    }
}
