using System;
using System.Linq;

namespace SimplyBooks.Api.Tests.Common.Extensions
{
    public static class StringExtensions
    {
        public static string RandomString()
        {
            Random random = new Random();
            const int length = 8;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
