using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MvcCore.Helpers
{
    public static class ClaimsPrincipalExtensions
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            string value =   principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            int id = 0;
            int.TryParse(value, out id);

            return id;
        }
        public static string GetArea(this ClaimsPrincipal principal)
        {
            if (principal == null)
                throw new ArgumentNullException(nameof(principal));

            return principal.FindFirstValue(ClaimTypes.Actor);
        }
    }
}