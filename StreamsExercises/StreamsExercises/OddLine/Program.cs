using System;
using System.IO;
using System.Text;

namespace OddLine
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileDestinationPath = "../../text.txt";

            using (var reader = new StreamReader(fileDestinationPath))
            {
                var line = reader.ReadLine();
                var str = "";
                var count = 0;

                while (line != null)
                {
                    if (count % 2 !=0)
                    {
                        Console.WriteLine(line);
                    }
                    count++;
                    line = reader.ReadLine();
                }
            }


        }
    }
}
