using System;
using System.IO;
using System.Text;

namespace WritingToAFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "Кирилица";

            var fileStream = new FileStream("../../log.txt", FileMode.Create);

            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                fileStream.Write(bytes, 0, bytes.Length-1);
            }
            finally
            {
                fileStream.Close();
            }
        }
    }
}
