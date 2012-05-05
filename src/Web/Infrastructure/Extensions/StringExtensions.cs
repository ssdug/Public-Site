using System.Text.RegularExpressions;

namespace Web.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static string Slugify(this string input)
        {
            var str = input.RemoveAccents().ToLower();
            // invalid chars           
            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");
            
            // convert multiple spaces into one space   
            str = Regex.Replace(str, @"\s+", " ").Trim();
            
            // cut and trim 
            str = str.Substring(0, str.Length <= 45 ? str.Length : 45).Trim();
            str = Regex.Replace(str, @"\s", "-");
            
            return str; 
        }

        public static string RemoveAccents(this string input)
        {
            var bytes = System.Text.Encoding.GetEncoding("Cyrillic").GetBytes(input);
            return System.Text.Encoding.ASCII.GetString(bytes);
        }


    }
}