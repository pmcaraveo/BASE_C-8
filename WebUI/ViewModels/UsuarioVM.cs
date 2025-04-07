using System.ComponentModel;

namespace TDJ.WebUI.ViewModels
{
    public class UsuarioVM
    {
        public int Id { get; set; }
        
        [DisplayName("Nombre de usuario")]
        public string UserName { get; set;  }

        [DisplayName("Correo institucional")]
        public string Email { get; set; }

        [DisplayName("Nombre completo")]
        public string NombreCompleto { get; set; }

        [DisplayName("Activo?")]
        public bool Activo { get; set; }
    }
}