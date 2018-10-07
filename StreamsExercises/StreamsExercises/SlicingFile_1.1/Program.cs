using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace SlicingFile_1._1
{
    class Program
    {
        static List<string> paths = new List<string>();

        static void Main(string[] args)
        {
            //Include => Problem 5. Slicing File + Problem 6.	Zipping Sliced Files     
            var sourceFile = "../files/sliceMe.mp4";
            var destination = "../files/";
            int parts = 4;

            Slice(sourceFile, destination, parts);
            Assemble(paths, destination);
        }
        static  void Assemble(List<string> files, string destinationDirectory)
        {
            byte[] buffer;
            destinationDirectory += "assembled.mp4";
            using (FileStream writeFile = new FileStream(destinationDirectory, FileMode.Create))
            {
                foreach (var path in paths)
                {
                    using (var readFile = new FileStream(path, FileMode.Open))
                    {
                        while (true)
                        {
                            buffer = new byte[readFile.Length];
                            int byteCount = readFile.Read(buffer, 0, buffer.Length);
                            if (byteCount==0)
                            {
                                break;
                            }
                            writeFile.Write(buffer, 0, buffer.Length);

                        }

                    }
                }
            }
        
        }
        static void Slice(string sourceFile, string destination, int parts)
        {
            using (FileStream readFile = new FileStream(sourceFile, FileMode.Open))
            {
                long size = (readFile.Length / parts);
                byte[] buffer = new byte[size];

                for (int i = 0; i < parts; i++)
                {
                    var destPath = destination + $"Path{i}.mp4";
                    paths.Add(destPath);

                    using (FileStream writeFile = new FileStream(destPath, FileMode.Create))
                    {
                        int byteCount = readFile.Read(buffer, 0, buffer.Length);
                        writeFile.Write(buffer, 0, buffer.Length);                        
                    }
                    using (GZipStream gz = new GZipStream(new FileStream(destPath + ".gz", FileMode.Create), CompressionMode.Compress, false))
                    {
                        gz.Write(buffer, 0, buffer.Length);
                    }
                }
            }
        }
    }
}

