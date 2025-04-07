using System;

namespace MvcCore.Helpers
{
    public static class EnumExtensions
    {
        public static int ToInt(this Enum enu)
        {
            return Convert.ToInt32(enu);
        }
    }
}