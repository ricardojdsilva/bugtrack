using BugTracker.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;

namespace BugTracker.Api.Security
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        public AuthorizeRolesAttribute(params User.RoleType[] roles)
        {
            if (roles.Any(r => r.GetType().BaseType != typeof(Enum)))
                throw new ArgumentException("roles");

            this.Roles = string.Join(",", roles.Select(r => Enum.GetName(r.GetType(), r)));
        }
    }
}
