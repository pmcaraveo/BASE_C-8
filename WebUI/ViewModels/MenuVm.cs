using Microsoft.AspNetCore.Mvc.Rendering;
using MvcCore.Helpers;
using System.ComponentModel;
using System.Linq;

namespace TDJ.WebUI.Models
{
    public class MenuVm
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Controlador { get; set; }

        [DisplayName("Acción")]
        public string Accion { get; set; }

        public string Area { get; set; }

        [DisplayName("Menú Padre")]
        public int? PadreId { get; set; }
        public bool Activo { get; set; }

        [DisplayName("Ícono (font awesome)")]
        public string Icon { get; set; }

        [DisplayName("Título")]
        public string Title { get; set; }
        public int? Orden { get; set; }
        public int Permiso { get; set; }
        public SelectList Menus { get; set; } = new MySelectList(Enumerable.Empty<SelectListItem>());        
        public SelectList Roles { get; set; } = new MySelectList(Enumerable.Empty<SelectListItem>());
    }
}