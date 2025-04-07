using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TSJ.Domain
{
    public partial class AspNetUserLogins
    {
        [Key]
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
        public string ProviderDisplayName { get; set; }
        public int UserId { get; set; }
    }
}
