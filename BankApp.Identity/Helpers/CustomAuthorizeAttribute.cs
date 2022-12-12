using BankApp.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BankApp.Identity.Helpers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private string[] _users = new string[0];
        public string Users
        {
            get
            {
                return string.Join(", ", _users);
            }
            set
            {
                _users = value != null ? value.Split(',', StringSplitOptions.TrimEntries) : new string[0];
            }
        }

        private string[] _roles = new string[0];
        public string Roles
        {
            get
            {
                return string.Join(", ", _roles);
            }
            set
            {
                _roles = value != null ? value.Split(',', StringSplitOptions.TrimEntries) : new string[0];
            }
        }


        public CustomAuthorizeAttribute(string role = null)
        {
            //Roles = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User?)context.HttpContext.Items["User"];
            if (user == null)
            {
                context.Result = new JsonResult(new
                {
                    message = "Unauthorized"
                })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
            if (_roles.Length > 0 && !_roles.Contains(user?.Role))
            {
                context.Result = new JsonResult(new
                {
                    message = "Unauthorized"
                })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
        }
    }
}
