using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Utils;
using MvcCore.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSJ.Application.Interfaces;
using TSJ.Domain;
using TSJ.Domain.Entities;
using TSJ.Infraestructure.Persistence;

namespace TSJ.Infraestructure.Services
{
    public class ConfiguracionService : IConfiguracionService
    {
        private readonly Con57DbContext _db;

        public ConfiguracionService(Con57DbContext db)
        {
            _db = db;
        }

        #region Almacenamiento
        /*
        public AlmacenamientoBase GetAlmacenamientoBaseByOrganoJudicialId(int organoJudicialId)
        {
            return _db.AlmacenamientoBase.FirstOrDefault(x => x.OrganoJudicialId == organoJudicialId);
        }

        public AlmacenamientoExpediente GetAlmacenamientoExpediente(int organoJudicialId, int tipoDocumentoId, int numero, int anio)
        {
            return _db.AlmacenamientoExpediente.FirstOrDefault(x => x.OrganoJudicialId == organoJudicialId
                                                               && x.TipoDocumentoId == tipoDocumentoId && x.NumeroExpediente == numero
                                                               && x.Anio == anio);
        }

        public async Task<OperationResult<AlmacenamientoExpediente>> GetAlmacenamientoByInicioId(int inicioId)
        {
            var entity = await _db.AlmacenamientoExpediente.FirstOrDefaultAsync(x => x.InicioId == inicioId);
            if (entity == null)
            {
                return new OperationResult<AlmacenamientoExpediente>(false, "No se encontró el registro.");
            }

            return new OperationResult<AlmacenamientoExpediente>(true, entity);
        }

        public async Task<OperationResult<AlmacenamientoExpediente>> GetAlmacenamientoByAmparoId(int amparoId)
        {
            var entity = await _db.AlmacenamientoExpediente.FirstOrDefaultAsync(x => x.InicioId == amparoId);
            if (entity == null)
            {
                return new OperationResult<AlmacenamientoExpediente>(false, "No se encontró el registro.");
            }

            return new OperationResult<AlmacenamientoExpediente>(true, entity);
        }

        public async Task<OperationResult> CreateAlmacenamientoBase(AlmacenamientoBase entity)
        {
            using (var transact = _db.Database.BeginTransaction())
            {
                try
                {
                    await _db.AddAsync(entity);
                    await _db.SaveChangesAsync();

                    transact.Commit();
                    return new OperationResult(true, "Se ha guardado el registro con éxito.");
                }
                catch (Exception ex)
                {
                    transact.Rollback();
                    return new OperationResult(false, "Ocurrió un error al intentar guardar el registro.");
                }
            }
        }

        public async Task<OperationResult> CreateAlmacenamientoExpediente(AlmacenamientoExpediente entity)
        {
            using (var transact = _db.Database.BeginTransaction())
            {
                try
                {
                    await _db.AddAsync(entity);
                    await _db.SaveChangesAsync();

                    transact.Commit();
                    return new OperationResult(true, "Se ha guardado el registro con éxito.");
                }
                catch (Exception ex)
                {
                    transact.Rollback();
                    return new OperationResult(false, "Ocurrió un error al intentar guardar el registro.");
                }
            }
        }
        */
        #endregion

        #region Menús
        public IQueryable<Menu> GetMenus()
        {
            return _db.Menu.ToList().AsQueryable();
        }

        public IQueryable<ViewMenuRol> GetMenusRol()
        {
            return _db.ViewMenuRol.ToList().AsQueryable();
        }

        public async Task<List<ViewMenuUsuario>> GetMenuUsuario()
        {
            return await _db.ViewMenuUsuario.ToListAsync();
        }

        public async Task<List<ViewMenuUsuario>> GetMenuUsuarioById(int usuarioId)
        {
            return await _db.ViewMenuUsuario.Where(x => x.UsuarioId == usuarioId).ToListAsync();
        }

        public async Task<MenuUsuario> GetMenuUsuarioById2(int usuarioId, int menuId)
        {
            return await _db.MenuUsuario.FirstOrDefaultAsync(x => x.UsuarioId == usuarioId && x.MenuId == menuId);
        }

        public async Task<OperationResult<Menu>> GetMenuById(int id)
        {
            var entity = await _db.Menu.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return new OperationResult<Menu>(false, "No se encontró el registro.");
            }

            return new OperationResult<Menu>(true, entity);
        }

        public async Task<OperationResult> CreateMenuAsync(Menu entity)
        {
            using (var transact = _db.Database.BeginTransaction())
            {
                try
                {
                    entity.Activo = true;
                    await _db.AddAsync(entity);
                    await _db.SaveChangesAsync();

                    transact.Commit();
                    return new OperationResult<Menu>(true, entity, "Se ha guardado el menú con éxito.");
                }
                catch (Exception ex)
                {
                    transact.Rollback();
                    return new OperationResult(false, "Ocurrió un error al intentar guardar el menú.");
                }
            }
        }

        public async Task<OperationResult> UpdateMenuAsync(Menu entity)
        {
            using (var transact = _db.Database.BeginTransaction())
            {
                try
                {
                    var getExistente = await GetMenuById(entity.Id);
                    var existente = getExistente.Entity;

                    if (!getExistente.Succeeded)
                    {
                        return new OperationResult(false, getExistente.Message);
                    }

                    if (existente.Nombre != entity.Nombre || existente.Controlador != entity.Controlador
                        || existente.Accion != entity.Accion || existente.PadreId != entity.PadreId
                        || existente.Activo != entity.Activo || existente.Icon != entity.Icon || existente.Title != entity.Title
                        || existente.Orden != entity.Orden
                        )
                    {
                        existente.Nombre = entity.Nombre;
                        existente.Controlador = entity.Controlador;
                        existente.Accion = entity.Accion;
                        existente.PadreId = entity.PadreId;
                        existente.Activo = entity.Activo;
                        existente.Icon = entity.Icon;
                        existente.Title = entity.Title;
                        existente.Orden = entity.Orden;
                        _db.Update(existente);
                        await _db.SaveChangesAsync();

                        transact.Commit();
                        return new OperationResult<Menu>(true, existente, "Registro actualizado con éxito.");
                    }
                    else
                    {
                        return new OperationResult(false, "No existen datos recientes para actualizar el registro.");
                    }

                }
                catch (Exception)
                {
                    transact.Rollback();
                    return new OperationResult(false, "Ocurrió un error al intentar guardar el registro.");
                }
            }
        }

        public async Task<OperationResult> CreateMenuRol(List<int> menuId, int rolId)
        {
            using (var transact = _db.Database.BeginTransaction())
            {
                try
                {
                    var existente = await _db.MenuRol.ToListAsync();

                    for (int i = 0; i < menuId.Count; i++)
                    {
                        var menuRol = new MenuRol
                        {
                            MenuId = menuId[i],
                            RolId = rolId,
                        };
                        await _db.AddAsync(menuRol);
                        await _db.SaveChangesAsync();

                    }

                    transact.Commit();
                    return new OperationResult(true, "Se ha guardado el menú con éxito.");
                }
                catch (Exception ex)
                {
                    transact.Rollback();
                    return new OperationResult(false, "Ocurrió un error al intentar guardar el menú.");
                }
            }
        }

        public async Task<OperationResult> CreateMenuUsuario(List<int> menuId, int usuarioId)
        {
            using (var transact = _db.Database.BeginTransaction())
            {
                try
                {
                    for (int i = 0; i < menuId.Count; i++)
                    {
                        var menuUser = new MenuUsuario
                        {
                            MenuId = menuId[i],
                            UsuarioId = usuarioId,
                        };
                        await _db.AddAsync(menuUser);
                        await _db.SaveChangesAsync();
                    }

                    transact.Commit();
                    return new OperationResult(true, "Se ha guardado el menú con éxito.");
                }
                catch (Exception ex)
                {
                    transact.Rollback();
                    return new OperationResult(false, "Ocurrió un error al intentar guardar el menú.");
                }
            }
        }

        public async Task<OperationResult> RemoveMenuUsuario(List<int> menuId, int usuarioId)
        {
            using (var transact = _db.Database.BeginTransaction())
            {
                try
                {
                    for (int i = 0; i < menuId.Count; i++)
                    {
                        var getMenu = await GetMenuUsuarioById2(usuarioId, menuId[i]);

                        _db.Remove(getMenu);
                        await _db.SaveChangesAsync();
                    }
                    transact.Commit();
                    return new OperationResult(true, "Se ha quitado el menú con éxito.");
                }
                catch (Exception ex)
                {
                    transact.Rollback();
                    return new OperationResult(false, "Ocurrió un error al intentar quitar el menú.");
                }
            }
        }
        #endregion
    }
}