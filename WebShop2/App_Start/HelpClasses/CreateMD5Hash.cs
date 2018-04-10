using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using WebShop2.Models.Payex;

namespace WebShop2.App_Start.HelpClasses
{
    public class CreateMD5Hash
    {
        private string hash = "";

        public CreateMD5Hash(string stringToHash)
        {

            MD5 hash = MD5.Create();

            hash = new MD5CryptoServiceProvider();

            byte[] data = hash.ComputeHash(Encoding.Default.GetBytes(stringToHash));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {

                sBuilder.Append(data[i].ToString("x2"));

            }

            setHash(sBuilder.ToString());
        }

        private void setHash(string hash)
        {
            this.hash = hash;
        }

        public string getHash()
        {
            return this.hash;
        }
    }

}