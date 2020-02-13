using System;
using System.IO;

namespace MyFileStream
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"D:\";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            Console.WriteLine("Enter string to wtite");
            string text = Console.ReadLine();
            using (FileStream fStream = new FileStream($"{path}note.txt", FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fStream.Write(array, 0, array.Length);
                Console.WriteLine("End write");
            }
            using (FileStream rStream = File.OpenRead($"{path}note.txt"))
            {
                byte[] array = new byte[rStream.Length];
                rStream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine(textFromFile);
            }
        }
    }
}
