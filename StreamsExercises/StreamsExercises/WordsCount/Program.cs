using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputPath = "../../words.txt";
            var outputPath = "../../result.txt";
            var textPath = "../../text.txt";
            //
            Dictionary<string, int> wordsCounter = new Dictionary<string, int>();
            var wordsList = new List<string>();
            //
            try
            {
                using (var reader = new StreamReader(inputPath))
                {
                    string words = reader.ReadLine();

                    while (words != null)
                    {
                        wordsCounter.Add(words, 0);
                        wordsList.Add(words);
                        words = reader.ReadLine();
                    }
                }
                //
                using (var rederLine = new StreamReader(textPath))
                {
                    string line = rederLine.ReadLine();
                    while (line != null)
                    {
                        foreach (var word in wordsList)
                        {

                            var pattern = $"(?<=[^a-zA-Z]){word}(?=[^a-zA-Z])";
                            var count = Regex.Matches(line, pattern, RegexOptions.IgnoreCase).Count;
                            wordsCounter[word] += count;
                        }
                        line = rederLine.ReadLine();
                    }
                }
                using (var write = new StreamWriter(outputPath))
                {
                    foreach (var word in wordsCounter.Keys.OrderByDescending(x => wordsCounter[x]))
                    {
                        write.WriteLine($"{word} {wordsCounter[word]}");
                    }
                }
                Console.WriteLine("Program is finished!");

            }
            catch (Exception)
            {
                Console.WriteLine("Program is abort! Error.");
            }
           


        }
    }
}
