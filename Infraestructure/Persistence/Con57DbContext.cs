using Microsoft.EntityFrameworkCore;
using System;
using System.Text.RegularExpressions;
using TSJ.Domain;

namespace TSJ.Infraestructure.Persistence
{
    public class Con57DbContext : DbContext
    {
        public Con57DbContext (DbContextOptions<Con57DbContext> options)
            : base(options)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
        }

        //Identity
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }

        //Tablas
        public DbSet<Menu> Menu { get; set; }
        public DbSet<MenuRol> MenuRol { get; set; }
        public DbSet<MenuUsuario> MenuUsuario { get; set; }
        //public DbSet<AlmacenamientoBase> AlmacenamientoBase { get; set; }

        //Vistas
        public DbSet<ViewUserRol> ViewUserRol { get; set; }
        public DbSet<ViewMenuRol> ViewMenuRol { get; set; }
        public DbSet<ViewMenuUsuario> ViewMenuUsuario { get; set; }
        public DbSet<ViewDateTimeServer> ViewDateTimeServer { get; set; }


        //bitacora
        #region 
        public DbSet<UserActivity> UserActivity { get; set; }
        #endregion


    }
}