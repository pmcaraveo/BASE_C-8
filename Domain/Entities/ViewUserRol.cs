using System;

namespace TSJ.Domain
{
    public class ViewUserRol
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }
        public int RoleId { get; set; }
        public string Rol { get; set; }
        public int? UsuarioRegistraId { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int? UsuarioActualizaId { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string NombreCompleto { get; set; }
        //public int? AdministracionId { get; set; }
        //public int? OrganoJudicialId { get; set; }
    }
}