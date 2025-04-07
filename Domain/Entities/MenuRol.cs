using System;
using System.ComponentModel.DataAnnotations;

namespace TSJ.Domain
{
    public class MenuRol
    {
        public int Id { get; set; }        
        public int MenuId { get; set; }        
        public int RolId { get; set; }
    }
}