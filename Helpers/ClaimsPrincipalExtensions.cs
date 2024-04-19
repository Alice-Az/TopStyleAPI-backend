using System.Security.Claims;

namespace TopStyleAPI.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal user)
        {
            var userIdString = user.Claims.First(c => c.Type == ClaimTypes.Sid).Value;
            return int.TryParse(userIdString, out int userId) ? userId : 0;
        }
    }
}
