using MvcCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSJ.Domain;

namespace TSJ.Application.Interfaces
{
    public interface IConfiguracionService
    {
        #region Almacenamiento
        /*
        AlmacenamientoBase GetAlmacenamientoBaseByOrganoJudicialId(int organoJudicialId);
        AlmacenamientoExpediente GetAlmacenamientoExpediente(int organoJudicialId, int tipoDocumentoId, int numero, int anio);
        Task<OperationResult> CreateAlmacenamientoBase(AlmacenamientoBase entity);
        Task<OperationResult<AlmacenamientoExpediente>> GetAlmacenamientoByInicioId(int inicioId);
        Task<OperationResult<AlmacenamientoExpediente>> GetAlmacenamientoByAmparoId(int amparoId);
        Task<OperationResult> CreateAlmacenamientoExpediente(AlmacenamientoExpediente entity);
        */
        #endregion

        #region Menús

        IQueryable<Menu> GetMenus();
        IQueryable<ViewMenuRol> GetMenusRol();
        Task<OperationResult<Menu>> GetMenuById(int id);
        Task<List<ViewMenuUsuario>> GetMenuUsuario();
        Task<List<ViewMenuUsuario>> GetMenuUsuarioById(int usuarioId);

        Task<OperationResult> CreateMenuAsync(Menu entity);
        Task<OperationResult> UpdateMenuAsync(Menu entity);
        Task<OperationResult> CreateMenuRol(List<int> menuId, int rolId);
        Task<OperationResult> CreateMenuUsuario(List<int> menuId, int usuarioId);
        Task<OperationResult> RemoveMenuUsuario(List<int> menuId, int usuarioId);

        #endregion
    }
}
