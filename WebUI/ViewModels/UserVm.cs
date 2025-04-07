using Microsoft.AspNetCore.Mvc.Rendering;
using MvcCore.Helpers;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TDJ.WebUI.ViewModels
{
    public class UserVm
    {
        public int Id { get; set; }
        
        [DisplayName("Usuario")]
        public string UserName { get; set;  }

        [StringLength(100, ErrorMessage = "La {0} debe contener al menos {2} y m�ximo {1} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contrase�a")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contrase�a")]
        [Compare("Password", ErrorMessage = "La contrase�a y la confirmaci�n no coinciden.")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Rol")]
        public int RoleId { get; set; }

        public bool Activo { get; set; }
        
        public int? UsuarioRegistraId { get; set; }
        
        public DateTime? Fecharegistro { get; set; }
        
        public int? UsuarioActualizaId { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        public SelectList Roles { get; set; } = new MySelectList(Enumerable.Empty<SelectListItem>());
    }
}