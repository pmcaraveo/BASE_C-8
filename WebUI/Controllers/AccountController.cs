using AutoMapper;
using TDJ.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Mvc.JQuery.DataTables;
using MvcCore.Helpers;
using QueryInterceptor.Core;
using System;
using System.Linq;
using System.Threading.Tasks;
using TDJ.WebUI.DataTables;
using TSJ.Application.Interfaces;
using TSJ.Domain;
using static TSJ.Application.Extensions.CaseInsensitive;

namespace TDJ.WebUI.Controllers
{
    public class AccountController : BaseController
    {
        #region Variables privadas
        //Declaración de variables para inyección de dependencias
        private readonly IAccountService _service;
        private readonly ICatalogoService _catalogo;
        private readonly IMapper _map;
        private readonly IConfiguracionService _conf;
        #endregion

        #region Constructor
        public AccountController(IAccountService service,
            ICatalogoService catalogo, IConfiguracionService conf,
            IMapper map)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
            _catalogo = catalogo ?? throw new ArgumentNullException(nameof(catalogo));
            _map = map ?? throw new ArgumentNullException(nameof(map));
            _conf = conf ?? throw new ArgumentNullException(nameof(conf));
        }
        #endregion

        #region Index
        public IActionResult Index()
        {
            var getDataUrl = Url.Action(nameof(AccountController.GetPaged));
            var vm = DataTablesHelper.DataTableVm<UsersDt>("tblUser", getDataUrl);
            vm.StateSave = true;
            // activar para filtrado por columnas
            vm.ColVis = true;
            vm.Filter = true; //Enable filtering
            vm.UseColumnFilterPlugin = true;
            vm.TableClass = "table-bordered table-sm table-hover";
            vm.LengthMenu = LengthMenuVm.Default();
            vm.PageLength = 10;
            // ocultar la caja de búsqueda y mostrar n registros
            vm.Dom = "lBrtip"; // default: lfrtip

            return View(vm);
        }

        public DataTablesResult<UsersDt> GetPaged(DataTablesParam dtParams)
        {
            var data = _service.GetUserRol()
                            .Select(x => new UsersDt()
                            {
                                Id = x.Id,
                                UserName = x.UserName,
                                Email = x.Email,
                                Rol = x.Rol,
                                Activo = x.Activo,
                            }).InterceptWith(new SetComparerExpressionVisitor(StringComparison.CurrentCultureIgnoreCase));

            return DataTablesResult.Create(data, dtParams, x => new {
                Tools = DataTablesHelpers.ButtonEdit(Url.Action("Detalle", new { x.Id })),
                Activo = DataTablesHelpers.GetBooleanColumn(x.Activo),
            });
        }
        #endregion

        #region Edit
        public async Task<IActionResult> Edit(int id)
        {
            var usuario = _service.GetUserRol().FirstOrDefault(x => x.Id == id);

            if (usuario == null)
            {
                MessageDanger("No se encontró el usuario.");
            }

            var model = new UserVm
            {
                Id = usuario.Id,
                UserName = usuario.UserName,
                Password = usuario.Password,
                RoleId = usuario.RoleId,
                Activo = usuario.Activo,
                Roles = new MySelectList(await _catalogo.GetRolesAsync()),
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UserVm model)
        {
            if (ModelState.IsValid)
            {
                model.UsuarioActualizaId = User.GetUserId();
                model.FechaActualizacion = DateTime.Now;
                var update = await _service.UpdateUser(_map.Map<ViewUserRol>(model));
                if (update.Succeeded)
                {
                    MessageSuccess(update.Message);
                    return RedirectToAction("Index", new { update });
                }
                else
                {
                    MessageDanger(update.Message);
                }
            }
            model.Roles = new MySelectList(await _catalogo.GetRolesAsync());
            return View(model);
        }
        #endregion

        #region Detalles
        public async Task<IActionResult> Detalle(int id)
        {
            var result = await _service.GetUserbyId(id);
            if (!result.Succeeded)
            {
                MessageDanger(result.Message);
                return View();
            }
            var model = _map.Map<UsuarioVM>(result.Entity);

            return await Task.Run(() => View(model));
        }
        #endregion

        #region SubMenú        
        public IActionResult GetMenuRol()
        {
            var result = _conf.GetMenusRol();

            return Json(result);
        }        

        [HttpGet]
        public async Task<IActionResult> GetSubMenu(int menuId)
        {
            return await Task.FromResult(ViewComponent("SubMenu", new { menuId }));
        }

        [HttpGet]
        public async Task<IActionResult> GetTreeMenu(int menuId)
        {
            return await Task.FromResult(ViewComponent("TreeMenu", new { menuId }));
        }
        #endregion

        #region Change Area/Órgano Judicial
        /*
        [HttpGet]
        public IActionResult ChangeArea(int organoJudicialId)
        {
            if (organoJudicialId == 0)
            {
                var area = _service.GetOrganoJudicialByUser(User.GetUserId());
                Area = area;
                return Json(Area);
            }

            Area = organoJudicialId;

            return Json(Area);
        }
        */
        #endregion
    }
}