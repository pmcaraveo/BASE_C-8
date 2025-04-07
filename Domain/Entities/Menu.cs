using System;
using System.ComponentModel.DataAnnotations;

namespace TSJ.Domain
{
    public class Menu
    {
        public int Id { get; set; }        
        public string Nombre { get; set; }        
        public string Controlador { get; set; }        
        public string Accion { get; set; }
        public string Area { get; set; }
        public int? PadreId { get; set; }        
        public bool Activo { get; set; }
        public string Icon { get; set; }        
        public string Title { get; set; }        
        public int? Orden { get; set; }
        public int Permiso { get; set; }
    }
}