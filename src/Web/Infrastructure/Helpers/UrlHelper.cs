using System;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace Web.Infrastructure.Helpers
{
    public static class UrlExtensions
    {
        public static string Gravatar(this UrlHelper url, string emailAddress)
        {
            var baseUrl = "http://www.gravatar.com/avatar/{0}";
            return String.Format(baseUrl, MD5Hash(emailAddress.ToLower()));
        }

        public static string Gravatar(this UrlHelper url, string emailAddress, int size)
        {
            var baseUrl = "http://www.gravatar.com/avatar/{0}?s={1}";
            return String.Format(baseUrl, MD5Hash(emailAddress.ToLower()), size);
        }

        private static string MD5Hash(string input)
        {
            var hash = new StringBuilder();
            var md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (var i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }
    }
}