using System;
using System.IO;

namespace CopyingFile.cs
{
    class Program
    {
        const string sheepPath =  "../../sheep.jpg";
        const string destinationPath = "../../result.jpg";

        static void Main(string[] args)
        {
  
            using (var source = new FileStream(sheepPath, FileMode.Open))
            {
                using (var destination = new FileStream(destinationPath, FileMode.Create))
                {
                    double fileLenght = source.Length;
                    byte[] buffer = new byte[4096];

                    while (true)
                    {
                        var readBytes = source.Read(buffer, 0, buffer.Length);

                        if (readBytes == 0)
                        {
                            break;
                        }
                        destination.Write(buffer, 0, readBytes);
                    }

                }
            }
        }
    }
}
