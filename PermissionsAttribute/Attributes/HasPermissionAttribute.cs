using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PermissionsAttribute.Constants;

namespace PermissionsAttribute.Attributes
{
    public class HasPermissionAttribute : ActionFilterAttribute
    {
        private Permissions Permission { get; }

        public HasPermissionAttribute(Permissions permission)
        {
            Permission = permission;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == "permission" && c.Value == Permission.ToString());
            if (!hasClaim)
            {
                context.Result = new ForbidResult();
            }
        }
    }
}
