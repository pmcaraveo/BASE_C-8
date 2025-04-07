using MvcCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSJ.Domain;

namespace TSJ.Application.Interfaces
{
    public interface ICatalogoService
    {
        //List<SelectListModel> GetMaterias();
        //List<SelectListModel> GetViaProcesamiento(int materiaId);
        //List<SelectListModel> GetOrganoJudicial(int materiaId);
        //List<SelectListModel> GetJuicio(int materiaId);
        //List<SelectListModel> GetOrganoJudicial();
        //List<SelectListModel> GetOrganoJudicialById(int organoJudicialId);
        //List<SelectListModel> GetOrganoJudicialByAdministracion(int administracionId);
        //List<SelectListModel> GetAdministracion();
        //List<SelectListModel> GetSexo();
        //List<SelectListModel> GetTipoParte();
        //IQueryable<OrganoJudicial> GetOrganosJudiciales();
        //List<SelectListModel> GetMateriasById(int materiaId);
        Task<List<SelectListModel>> GetUsuariosAsync();
        Task<List<SelectListModel>> GetRolesAsync();
        //Task<List<SelectListModel>> GetSecretarios(int juezId);
        Task<List<SelectListModel>> GetMenuSelectList();
        //Task<List<SelectListModel>> GetLocalidades();
        //Task<List<SelectListModel>> GetEntidadFederativa();
    }
}