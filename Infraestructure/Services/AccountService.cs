using Microsoft.EntityFrameworkCore;
using MvcCore.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TSJ.Domain;
using TSJ.Application.Interfaces;
using TSJ.Infraestructure.Persistence;
using Microsoft.AspNetCore.Identity;
using TSJ.Infraestructure.Identity;

namespace TSJ.Infraestructure.Services
{
    public class AccountService : IAccountService
    {
        #region Variables Privadas
        private readonly Con57DbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        #endregion

        #region Constructor
        public AccountService(Con57DbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        #endregion

        #region GET
        public IQueryable<ViewUserRol> GetUserRol()
        {
            return _db.ViewUserRol.ToList().AsQueryable();
        }

        public async Task<OperationResult<AspNetUsers>> GetUser(string user)
        {
            var entity = await _db.AspNetUsers.FirstOrDefaultAsync(x => x.UserName == user);
            if (entity == null)
            {
                return new OperationResult<AspNetUsers>(false, "No se encontró el registro.");
            }
            return new OperationResult<AspNetUsers>(true, entity);
        }

        public async Task<OperationResult<AspNetUsers>> GetUserbyId(int id)
        {
            var entity = await _db.AspNetUsers.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return new OperationResult<AspNetUsers>(false, "No se encontró el registro.");
            }
            return new OperationResult<AspNetUsers>(true, entity);
        }

        public async Task<OperationResult<AspNetRoles>> GetRolById(int id)
        {
            var entity = await _db.AspNetRoles.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return new OperationResult<AspNetRoles>(false, "No se encontró el registro.");
            }
            return new OperationResult<AspNetRoles>(true, entity);
        }

        public async Task<OperationResult<AspNetUserRoles>> GetUserRolById(int userId)
        {
            var entity = await _db.AspNetUserRoles.FirstOrDefaultAsync(x => x.UserId == userId);
            if (entity == null)
            {
                return new OperationResult<AspNetUserRoles>(false, "No se encontró el registro.");
            }

            return new OperationResult<AspNetUserRoles>(true, entity);
        }

        public async Task<List<ViewMenuRol>> GetMenuByRol(int userId)
        {
            var rol = await _db.AspNetUserRoles.FirstOrDefaultAsync(x => x.UserId == userId);
            return _db.ViewMenuRol.Where(x => x.RolId == rol.RoleId & x.Activo == true).OrderBy(x => x.Orden).AsQueryable().ToList();
        }
        #endregion

        public async Task<OperationResult> CreateDetailsUser(int administracionId, int? organoJudicialId, int rol, int usuarioId)
        {
            using (var transact = _db.Database.BeginTransaction())
            {
                try
                {
                    //var admon = new UsuarioAdministracion();
                    //var juzgado = new UsuarioOrganoJudicial();

                    if (rol == 2 || rol == 3 || rol == 4 || rol == 9)
                    {
                        //admon.UsuarioId = usuarioId;
                        //admon.AdministracionId = administracionId;
                        //await _db.AddAsync(admon);
                        await _db.SaveChangesAsync();
                    }

                    if (rol == 5 || rol == 6 || rol == 7 || rol == 8)
                    {
                        //juzgado.UsuarioId = usuarioId;
                        //juzgado.OrganoJudicialId = organoJudicialId;
                        //await _db.AddAsync(juzgado);
                        await _db.SaveChangesAsync();
                    }

                    transact.Commit();
                    return new OperationResult(true, "Usuario creado con éxito.");
                }
                catch (Exception ex)
                {
                    transact.Rollback();
                    return new OperationResult(false, "Ocurrió un error al intentar guardar el registro." + ex);
                }
            }
        }

        public async Task<OperationResult> UpdateUser(ViewUserRol entity)
        {
            using (var transact = _db.Database.BeginTransaction())
            {
                try
                {
                    var usuario = await _db.AspNetUsers.FirstOrDefaultAsync(x => x.Id == entity.Id);
                    var roles = await _db.AspNetUserRoles.FirstOrDefaultAsync(x => x.UserId == entity.Id);
                    if (usuario == null)
                    {
                        return new OperationResult(false, "No se encontró al usuario.");
                    }

                    if (roles == null)
                    {
                        return new OperationResult(false, "No se encontró el rol.");
                    }

                    if (usuario.UserName != entity.UserName || usuario.Activo != entity.Activo || usuario.PasswordHash != entity.Password || roles.RoleId != entity.RoleId)
                    {
                        ApplicationUser user = await _userManager.FindByNameAsync(entity.UserName);
                        usuario.UserName = entity.UserName;
                        usuario.PasswordHash = _userManager.PasswordHasher.HashPassword(user, entity.Password);
                        usuario.Activo = entity.Activo;
                        usuario.UsuarioActualizaId = entity.UsuarioActualizaId;
                        usuario.FechaActualizacion = entity.FechaActualizacion;
                        roles.RoleId = entity.RoleId;
                        _db.Update(usuario);
                        _db.Update(roles);
                        await _db.SaveChangesAsync();
                        transact.Commit();
                        return new OperationResult(true, "Registro actualizado con éxito.");
                    }
                    else
                    {
                        return new OperationResult(true, "No existen datos recientes para actualizar el registro.");
                    }
                }
                catch (Exception ex)
                {
                    transact.Rollback();
                    return new OperationResult(false, "Ocurrió un error al intentar guardar el registro." + ex);
                }
            }
        }
    }
}