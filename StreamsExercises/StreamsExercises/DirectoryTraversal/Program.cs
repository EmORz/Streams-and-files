using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string directory = @"C:\Users\User\Desktop";
            string[] files = Directory.GetFiles(directory);
            var dict = new Dictionary<string, Dictionary<string, double>>();

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                if (dict.ContainsKey(fileInfo.Extension))
                {
                    dict[fileInfo.Extension].Add(fileInfo.Name, fileInfo.Length);
                }
                else
                {
                    var tempD = new Dictionary<string, double>();
                    tempD.Add(fileInfo.Name, fileInfo.Length);
                    dict.Add(fileInfo.Extension, tempD);
                }
            }
            string path = @"C:\Users\User\Desktop\report.txt";

            var writer = new StreamWriter(path);

            using (writer)
            {
                foreach (var kvp in dict.OrderByDescending(x => x.Value.Count).ThenBy(c => c.Key))
                {
                    writer.WriteLine(kvp.Key);
                    foreach (var kvp1 in kvp.Value.OrderBy(x => x.Value))
                    {
                        writer.WriteLine($"--"+kvp1.Key+$" - {kvp1.Value/1024:f3}kb");                    }
                }
            }

        }

  
    }
}
