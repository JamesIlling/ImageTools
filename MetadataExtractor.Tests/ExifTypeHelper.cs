using System;
using System.Linq;

namespace MetadataExtractor.Tests
{
    using System.Text;

    static class ExifTypeHelper
    {
        public static  byte[] CreateRational(uint numerator, uint denominator)
        {
            return BitConverter.GetBytes(numerator).Concat(BitConverter.GetBytes(denominator)).ToArray();
        }

        public static byte[] CreateSignedRational(int numerator, int denominator)
        {
            return BitConverter.GetBytes(numerator).Concat(BitConverter.GetBytes(denominator)).ToArray();
        }

        public static byte[] CreateString(string text)
        {
            return Encoding.ASCII.GetBytes(text + "\0");
        }
    }
}
