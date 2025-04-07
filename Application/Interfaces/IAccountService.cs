using MvcCore.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSJ.Domain;

namespace TSJ.Application.Interfaces
{
    public interface IAccountService
    {
        IQueryable<ViewUserRol> GetUserRol();
        Task<OperationResult<AspNetUsers>> GetUser(string user);
        Task<OperationResult<AspNetUsers>> GetUserbyId(int id);
        Task<OperationResult<AspNetRoles>> GetRolById(int id);
        Task<OperationResult<AspNetUserRoles>> GetUserRolById(int userId);
        Task<List<ViewMenuRol>> GetMenuByRol(int userId);
        //int GetArea(int userId);
        Task<OperationResult> UpdateUser(ViewUserRol entity);
        Task<OperationResult> CreateDetailsUser(int administracionId, int? organoJudicialId, int rol, int usuarioId);
    }
}