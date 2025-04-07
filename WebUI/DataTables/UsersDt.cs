using Mvc.JQuery.DataTables;

namespace TDJ.WebUI.DataTables
{
    public class UsersDt
    {
        [DataTables(Visible = false)]
        public int Id { get; set; }

        [DataTables(DisplayName = "Usuario")]
        public string UserName { get; set; }

        [DataTables(DisplayName = "Correo")]
        public string Email { get; set; }
        public string Rol { get; set; }
        public bool Activo { get; set; }

        [DataTables(DisplayName = " ", Searchable = false, Sortable = false, CssClassHeader = "opcion")]
        public string Tools { get; set; }       
    }
}