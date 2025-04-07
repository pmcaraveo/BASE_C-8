using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSJ.Application.Interfaces;

namespace TDJ.WebUI.ViewComponents
{
    public class AreaViewComponent : ViewComponent
    {
        private readonly IAccountService _service;

        public AreaViewComponent(IAccountService service)
        {
            _service = service;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var id = await _service.GetUser(User.Identity.Name);
            var ad = _service.GetUserAdmon().FirstOrDefault(x => x.UsuarioId == id.Entity.Id);
            var oj = _service.GetUserOrganoJudicial().FirstOrDefault(x => x.UsuarioId == id.Entity.Id);

            if (ad != null && oj == null)
            {
                
                return await Task.FromResult(View("Administracion", ad));
            }

            if (oj != null && ad != null)
            {
                return await Task.FromResult(View("Juzgado", oj));
            }

            return await Task.FromResult(View());
        }

    }
}
