using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TSJ.Application.Interfaces;

namespace TDJ.WebUI.ViewComponents
{
    public class RoleViewComponent : ViewComponent
    {
        private readonly IAccountService _service;

        public RoleViewComponent(IAccountService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = await _service.GetUser(User.Identity.Name);
            var result = _service.GetUserRol().Where(x => x.UsuarioId == id.Entity.Id);
            return await Task.FromResult(View(result));
        }
    }
}