using Microsoft.AspNetCore.Identity;
using System;

namespace TSJ.Infraestructure.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string NombreCompleto { get; set; }
        public bool Activo { get; set; }
        public int? UsuarioRegistraId { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? UsuarioActualizaId { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        //[NotMapped]
        //public SelectList Roles { get; set; }
        //[NotMapped, Required, Display(Name = "Rol")]
        //public int RolId { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public bool EsExterno { get; set; }
        public string RecoveryPassword { get; set; }
    }

    public class ApplicationRole : IdentityRole<int> { }
    public class ApplicationUserClaim : IdentityUserClaim<int> { }
    public class ApplicationUserToken : IdentityUserToken<int> { }
    public class ApplicationUserLogin : IdentityUserLogin<int> { }
    public class ApplicationUserRole : IdentityUserRole<int> { }
    public class ApplicationRoleClaim : IdentityRoleClaim<int> { }
}