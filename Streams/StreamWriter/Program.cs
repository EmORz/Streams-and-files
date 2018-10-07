using System;
using System.IO;

namespace StreamWriterr
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../Program.cs"))
            {
                using (var writer = new StreamWriter("reversed.txt"))
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        for (int i = line.Length - 1; i >= 0; i--)
                        {
                            writer.Write(line[i]);
                        }
                        writer.WriteLine();

                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
