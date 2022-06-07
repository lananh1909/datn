using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Business.Web
{
    public static class CommonHelper
    {
        public static string GennerateCode(string prefix)
        {
            const string AllowedChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random rng = new Random();
            var randomString = rng.NextStrings(AllowedChars, (4, 8));
            var stringBuilder = new StringBuilder();
            stringBuilder.Append(prefix);
            stringBuilder.Append(randomString);
            return stringBuilder.ToString();
        }

        private static string NextStrings(this Random rnd, string allowedChars, (int Min, int Max) length)
        {
            (int min, int max) = length;
            char[] chars = new char[max];
            int setLength = allowedChars.Length;

            int stringLength = rnd.Next(min, max + 1);

            for (int i = 0; i < stringLength; ++i)
            {
                chars[i] = allowedChars[rnd.Next(setLength)];
            }

            return new string(chars, 0, stringLength);
        }
    }
}
