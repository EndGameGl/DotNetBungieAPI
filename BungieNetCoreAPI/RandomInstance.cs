using System;
using System.Text;

namespace NetBungieAPI
{
    internal static class RandomInstance
    {
        private static readonly Random _rnd = new Random();
        private static readonly char[] _symbols = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".ToCharArray();
        internal static string GetRandomString(int length = 10)
        {
            if (length <= 0)
                throw new Exception("Invalid string length.");

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                sb.Append(_symbols[_rnd.Next(_symbols.Length)]);
            }
            return sb.ToString();
        }
    }
}
