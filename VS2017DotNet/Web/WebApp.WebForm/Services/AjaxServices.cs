using MySimpleServiceFramework;
using System;
using System.Security.Cryptography;
using System.Text;

namespace WebApp.WebForm.Services
{
    [MyService]
    public class AjaxServices
    {
        [MyServiceMethod]
        public string GetMd5(string str)
        {
            if (str == null)
                str = string.Empty;

            byte[] bb = (new MD5CryptoServiceProvider()).ComputeHash(Encoding.Default.GetBytes(str));
            return BitConverter.ToString(bb).Replace("-", "");
        }
    }
}