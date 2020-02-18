using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteBludata.Extensions
{
    public static class StringExtensions
    {
        public static string FormatarCpfCnpj(this string cpfCnpj) 
        {
            if (cpfCnpj.Length > 11)
            {
                return Convert.ToUInt64(cpfCnpj).ToString(@"00\.000\.000\/0000\-00");
            }
            else
            {
                return Convert.ToUInt64(cpfCnpj).ToString(@"000\.000\.000\-00");
            }
        }
    }
}
