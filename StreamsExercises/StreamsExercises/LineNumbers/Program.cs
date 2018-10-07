using System;
using System.IO;

namespace LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileDestinationPath = "../../text.txt";


            using (var reader = new StreamReader(fileDestinationPath))
            {
                using (var writer = new StreamWriter("../../keepTxtInfo.txt"))
                {
                    var line = reader.ReadLine();
                    var counter = 1;
                    while (line != null)
                    {
                        writer.WriteLine($"Line {counter++}: {line}");
                        line = reader.ReadLine();
                    }
                }
            }
            string messageForEnd = "Your data was been writen!\nHave I nice day :)";
            Console.WriteLine(messageForEnd);
        }
    }
}
