using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace MvcCore.Helpers

{
    /// <summary>
    /// Clase SelecListModel
    /// </summary>
    public class ListaInc
    {
        /// <summary>
        /// ID que se usará como valor en las listas de selección.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Texto a desplegar en listas de selección.
        /// </summary>
        public string Text { get; set; }

        ///// <summary>
        ///// Usuario que creo el registro. Usado para filtrar los catálogos que así lo requieran.
        ///// </summary>
        //public int User { get; set; }

       public string Idper { get; set; }

        public SelectList MiLista { get; set; } = new MySelectList(Enumerable.Empty<SelectListItem>());
    }
}