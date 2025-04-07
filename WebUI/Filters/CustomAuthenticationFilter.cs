using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Security.Claims;
using TSJ.Application.Interfaces;

namespace TDJ.WebUI.Filters
{
    public class CustomAuthorizationFilter : IAuthorizationFilter
    {
        private readonly IConfiguracionService _conf;
        public CustomAuthorizationFilter(IConfiguracionService conf)
        {
            _conf = conf;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (user.Identity.IsAuthenticated)
            {
                var rol = context.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
                var controller = context.RouteData.Values["controller"];
                var menus = _conf.GetMenusRol().Where(x => x.Name == rol);

                if (!menus.Contains(controller))
                {
                    context.Result = new BadRequestResult();
                }
            }
        }
    }
}