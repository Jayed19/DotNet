using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BvrsRestLibTestModule.Utils
{
    public static class Utils
    {
        static public bool CaseInsensitiveContains(string container, string part)
        {
            if (part == null) return true;
            if (container == null) return false;
            return CultureInfo.InvariantCulture.CompareInfo.IndexOf(container, part, CompareOptions.IgnoreCase) != -1;
        }
        static public bool CaseInsensitiveEquals(string one, string another)
        {
            if (one == null && another == null) return true;
            if (one == null || another == null) return false;
            return CultureInfo.InvariantCulture.CompareInfo.IndexOf(one, another, CompareOptions.IgnoreCase) != -1
                   && one.Length == another.Length;
        }
    }
}
