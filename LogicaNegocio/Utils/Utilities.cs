using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Utils
{
    public static class Utilities
    {
        /// <summary>
        /// Dado un texto lo encripta usando SHA256
        /// </summary>
        /// <param name="text"></param>
        /// <returns>Retorna el texto encriptado</returns>
        public static string Encriptar(string text)
        {
            StringBuilder sb = new StringBuilder();
            using(SHA256 hash  = SHA256.Create()) {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(text));
                foreach(byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
            
        }
    }
}
