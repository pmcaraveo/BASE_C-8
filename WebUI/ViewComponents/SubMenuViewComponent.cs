using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TSJ.Application.Interfaces;

namespace TDJ.WebUI.ViewComponents
{
    public class SubMenuViewComponent : ViewComponent
    {
        private readonly IAccountService _service;

        public SubMenuViewComponent(IAccountService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync(int menuId)
        {
            var id = await _service.GetUser(User.Identity.Name);
            var result = await _service.GetMenuByRol(id.Entity.Id);
            return await Task.FromResult(View(result.Where(x => x.PadreId == menuId).OrderBy(x => x.Orden).Distinct()));
        }
    }
}