using System;
using System.IO;

namespace LinesCounter
{
    class Program
    {

        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("sometextfile.txt");
            using (reader)
            {

                string line = reader.ReadLine();
                int counter = 0;

                while (line != null)
                {
                    counter++;
                    Console.WriteLine($"Line {counter}: {line}");
                    line = reader.ReadLine();
                }


            }
        }
    }
}
