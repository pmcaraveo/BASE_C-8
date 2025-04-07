using System;
using System.Collections.Generic;

namespace TSJ.Domain
{
    public partial class AspNetRoles
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
        public int Permiso { get; set; }
    }
}