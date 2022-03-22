using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq.Extensions
{
    public static class StringExtension
    {
        public static bool IsNameGood(this string name)
        {
            if (name.Length > 2)
            {
                if (char.IsLetter(name[0]) && char.IsUpper(name[0]))
                    return true;
            }

            return false;
        }
    }
}
