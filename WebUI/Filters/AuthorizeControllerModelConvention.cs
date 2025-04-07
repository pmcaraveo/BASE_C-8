using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using System.Linq;
using TSJ.Infraestructure.Persistence;

namespace TDJ.WebUI.Filters
{
    public class AuthorizeControllerModelConvention : IControllerModelConvention
    {
        private readonly Con57DbContext _db;

        public AuthorizeControllerModelConvention(Con57DbContext db)
        {
            _db = db;
        }

        public void Apply(ControllerModel controller)
        {
            var rolAdmon = _db.AspNetRoles.Where(x => x.Permiso == 1).Select(x => x.Name).ToArray();
            var rolJuzgado = _db.AspNetRoles.Where(x => x.Permiso == 2).Select(x => x.Name).ToArray();
            var rolTodos = _db.AspNetRoles.Select(x => x.Name).ToArray();
            var permisoAdmon = _db.ViewMenuRol.Where(x => x.Controlador != null && x.Permiso == 1).ToList();
            var permisoJuzgado = _db.ViewMenuRol.Where(x => x.Controlador != null && x.Permiso == 2).ToList();
            var permisoTodos = _db.ViewMenuRol.Where(x => x.Controlador != null && x.Permiso == 3).ToList();

            foreach (var item in permisoAdmon)
            {
                if (controller.ControllerName.Contains(item.Controlador))
                {
                    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                                                                 .RequireRole(rolAdmon).Build();
                    controller.Filters.Add(new AuthorizeFilter(policy));
                }
            }

            foreach (var item in permisoJuzgado)
            {
                if (controller.ControllerName.Contains(item.Controlador))
                {
                    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                                                                 .RequireRole(rolJuzgado).Build();
                    controller.Filters.Add(new AuthorizeFilter(policy));
                }
            }

            foreach (var item in permisoTodos)
            {
                if (controller.ControllerName.Contains(item.Controlador))
                {
                    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                                                                 .RequireRole(rolTodos).Build();
                    controller.Filters.Add(new AuthorizeFilter(policy));
                }
            }
        }
    }
}