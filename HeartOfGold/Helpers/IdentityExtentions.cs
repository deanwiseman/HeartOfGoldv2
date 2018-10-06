using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace HeartOfGold.Helpers
{
    public static class IdentityExtentions
    {
        public static string GetStudentNumber(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("UserName");

            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}