using System;
using System.Linq;
using System.Text;

namespace TestCoding
{
    class Program
    {
        static void Main(string[] args)
        {
            string unicodeString = "";
           
            // You can convert a string into a byte array
            byte[] asciiBytes = Encoding.ASCII.GetBytes(unicodeString);

            // You can convert a byte array into a char array
            char[] asciiChars = Encoding.ASCII.GetChars(asciiBytes);
            string asciiString = new string(asciiChars);

            // The resulting string is different due to the unsupported character for ASCII encoding
            //Console.WriteLine($"Unicode string: {unicodeString}");
            Console.WriteLine($"ASCII string: {asciiString}");
            Console.WriteLine(string.Join(" ", asciiBytes));
        }
    }
}
