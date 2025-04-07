using System;
using System.ComponentModel.DataAnnotations;

namespace TSJ.Domain
{
    public class MenuUsuario
    {        
        public int Id { get; set; }       
        public int MenuId { get; set; }        
        public int UsuarioId { get; set; }
    }
}