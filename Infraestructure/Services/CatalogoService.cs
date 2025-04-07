using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSJ.Application.Interfaces;
using TSJ.Domain;
using TSJ.Infraestructure.Persistence;

namespace TSJ.Infraestructure.Services
{
    public class CatalogoService : ICatalogoService
    {
        private readonly Con57DbContext _db;

        public CatalogoService(Con57DbContext db)
        {
            _db = db;
        }

        public async Task<List<SelectListModel>> GetUsuariosAsync()
        {
            return await _db.AspNetUsers.Where(x => x.Activo == true)
                .Select(x => new SelectListModel()
                {
                    Id = x.Id.ToString(),
                    Text = x.UserName + " - " + x.NombreCompleto,
                }).ToListAsync();
        }

        public async Task<List<SelectListModel>> GetRolesAsync()
        {
            return await _db.AspNetRoles.Select(x => new SelectListModel()
            {
                Id = x.Id.ToString(),
                Text = x.NormalizedName
            }).ToListAsync();
        }

        public async Task<List<SelectListModel>> GetMenuSelectList()
        {
            var result = await _db.Menu.Where(x => x.Activo == true)
                .Select(x => new SelectListModel()
                {
                    Id = x.Id.ToString(),
                    Text = x.Nombre + ObtenerMenus(x.Controlador, x.Accion, x.PadreId).ToString(),
                }).ToListAsync();

            return result;
        }

        #region Private
        private static string ObtenerMenus(string controlador, string accion, int? padreId)
        {
            var result = "";
            if (controlador == null && accion == null && padreId == null)
            {
                result = " - Menú principal";
            }
            if (controlador == null && accion == null && padreId != null)
            {
                result = " - Submenú";
            }
            if (controlador != null && accion != null && padreId != null)
            {
                result = " (" + controlador + ") - Tercer menú";
            }
            return result;
        }
        #endregion
    }
}