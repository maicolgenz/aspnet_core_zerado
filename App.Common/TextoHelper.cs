﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace App.Common
{
    public static class TextoHelper
    {
        public static bool CpfCnpjValido(this string text)
        {
            text = text.Replace(".", "").Replace("-", "").Replace("/", "").Replace("_", "");
            if (string.IsNullOrEmpty(text) || Convert.ToInt64(text) == 0)
            {
                return false;
            }
            else
            {
                int[] d = new int[14];
                int[] v = new int[2];
                int j, i, soma;
                string Sequencia, SoNumero;
                SoNumero = Regex.Replace(text, "[^0-9]", string.Empty);
                if (new string(SoNumero[0], SoNumero.Length) == SoNumero) return false;
                if (SoNumero.Length == 11)
                {
                    for (i = 0; i <= 10; i++) d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));
                    for (i = 0; i <= 1; i++)
                    {
                        soma = 0;
                        for (j = 0; j <= 8 + i; j++) soma += d[j] * (10 + i - j);

                        v[i] = (soma * 10) % 11;
                        if (v[i] == 10) v[i] = 0;
                    }
                    return (v[0] == d[9] & v[1] == d[10]);
                }
                else if (SoNumero.Length == 14)
                {
                    Sequencia = "6543298765432";
                    for (i = 0; i <= 13; i++) d[i] = Convert.ToInt32(SoNumero.Substring(i, 1));
                    for (i = 0; i <= 1; i++)
                    {
                        soma = 0;
                        for (j = 0; j <= 11 + i; j++)
                            soma += d[j] * Convert.ToInt32(Sequencia.Substring(j + 1 - i, 1));

                        v[i] = (soma * 10) % 11;
                        if (v[i] == 10) v[i] = 0;
                    }
                    return (v[0] == d[12] & v[1] == d[13]);
                }
                else
                {
                    return false;
                }
            }
        }
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
