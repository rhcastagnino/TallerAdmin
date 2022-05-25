using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Servicios
{
    public class Encriptador
    {
        private readonly byte[] Clave = Encoding.ASCII.GetBytes("etuoPIYRW.975346");
        private readonly byte[] IV = Encoding.ASCII.GetBytes("DevCasta3.18hAES");

        public string Encriptar(string texto)
        {
            byte[] inputBytes = Encoding.ASCII.GetBytes(texto);
            byte[] encripted;
            RijndaelManaged cripto = new RijndaelManaged();
            using (MemoryStream ms = new MemoryStream(inputBytes.Length))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateEncryptor(Clave, IV), CryptoStreamMode.Write))
                {
                    objCryptoStream.Write(inputBytes, 0, inputBytes.Length);
                    objCryptoStream.FlushFinalBlock();
                    objCryptoStream.Close();
                }
                encripted = ms.ToArray();
            }
            return Convert.ToBase64String(encripted);

        }

        public string Desencriptar(string texto)
        {
            byte[] inputBytes = Convert.FromBase64String(texto);
            byte[] resultBytes = new byte[inputBytes.Length];
            string textoLimpio = String.Empty;
            RijndaelManaged cripto = new RijndaelManaged();
            using (MemoryStream ms = new MemoryStream(inputBytes))
            {
                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateDecryptor(Clave, IV), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(objCryptoStream, true))
                    {
                        textoLimpio = sr.ReadToEnd();
                    }
                }
            }
            return textoLimpio;

        }
        public string Hash(string texto)
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5data = md5.ComputeHash(Encoding.ASCII.GetBytes(texto));
            return (new ASCIIEncoding()).GetString(md5data);
        }

    }
}
