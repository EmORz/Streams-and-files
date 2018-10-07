using System;
using System.IO;

namespace CopyBinaryFile.cs
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathPic = "../../copyMe.png";
            string output = "../../outCopyMe.png";
            //

            using (var source = new FileStream(pathPic, FileMode.Open))
            {
                using (var write = new FileStream(output, FileMode.Create))
                {
                    byte[] buffer = new byte[4069];
                    int readBytes = source.Read(buffer, 0, buffer.Length - 1);

                    while (readBytes!=0)
                    {
                        write.Write(buffer, 0, readBytes);
                        readBytes = source.Read(buffer, 0, buffer.Length - 1);
                    }
                }

            }
        }
    }
}
