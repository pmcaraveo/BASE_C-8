using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TSJ.Domain
{
    public partial class AspNetUserRoles
    {
        [Key]
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
