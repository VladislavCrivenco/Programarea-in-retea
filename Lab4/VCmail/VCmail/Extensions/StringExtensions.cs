using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VCmail.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string str)
        {
            if (String.IsNullOrWhiteSpace(str))
            {
                return true;
            }

            return false;
        }

        public static bool IsNotEmpty(this string str)
        {
            if (!String.IsNullOrWhiteSpace(str))
            {
                return true;
            }

            return false;
        }

    }
}
