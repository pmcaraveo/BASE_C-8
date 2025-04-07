using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TSJ.Domain
{
    public partial class AspNetUserTokens
    {
        [Key]
        public int UserId { get; set; }
        public string LoginProvider { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public virtual AspNetUsers User { get; set; }
    }
}
