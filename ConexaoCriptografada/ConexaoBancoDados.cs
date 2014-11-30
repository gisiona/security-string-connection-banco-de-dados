using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Configuration;

namespace ConexaoCriptografada
{
    public class ConexaoBancoDados
    {
        /// <summary>
        /// Metodo para criptografar a string de conexao 
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public string EncryptConnectionString(string connectionString)
        {
            Byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(connectionString);
            string encryptedConnectionString = Convert.ToBase64String(b);
            return encryptedConnectionString;
        }

       /// <summary>
       /// Metodo que descriptografa a string de conexao
       /// </summary>
       /// <returns></returns>
        public string DecryptConnectionString()
        {
            Byte[] b = Convert.FromBase64String(ConfigurationSettings.AppSettings["connectionString"]);
            string decryptedConnectionString = System.Text.ASCIIEncoding.ASCII.GetString(b);
            return decryptedConnectionString;
        }
    }
}
