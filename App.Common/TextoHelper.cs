using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Common
{
    public static class TextoHelper
    {
        public static string CpfCnpjFormatado(this string texto)
        {
            if (String.IsNullOrEmpty(texto))
            {
                return "";
            }

            texto = texto.Replace(".", "").Replace("-", "").Replace("/", "").Replace("_", "");

            if (texto.Length != 11 && texto.Length != 14)
            {
                if (texto.Length < 11)
                {
                    while (texto.Length < 11)
                    {
                        texto = "0" + texto;
                    }
                }
                else
                {
                    while (texto.Length < 14)
                    {
                        texto = "0" + texto;
                    }
                }
            }

            if (texto.Length == 11)
            {
                return Convert.ToUInt64(texto).ToString(@"000\.000\.000\-00");
            }
            else if (texto.Length == 14)
            {
                return Convert.ToUInt64(texto).ToString(@"00\.000\.000\/0000\-00");
            }

            return texto;
        }
    }
}
