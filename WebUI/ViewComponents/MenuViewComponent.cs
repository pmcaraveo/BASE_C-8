using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TSJ.Application.Interfaces;

namespace TDJ.WebUI.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly IAccountService _service;

        public MenuViewComponent(IAccountService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = await _service.GetUser(User.Identity.Name);
            var result = await _service.GetMenuByRol(id.Entity.Id);
            return await Task.FromResult(View(result.OrderBy(x => x.Orden).Distinct()));
        }
    }
}