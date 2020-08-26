using System;
using System.IO;

namespace DemoApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Ternary conditional operator
            string path = args.Length > 0 ? args[0] : "hello.txt";

            const string message = "Hello World!";

            // File.WriteAllText(path, message);
            File.WriteAllLines(path, new[] { message });
            // File.WriteAllBytes(path, new byte[] { 0x41, 0x20, 0x66, 0x0A, 0x0D });

            Console.WriteLine($"Wrote '{message}' to '{path}'");

            Console.WriteLine($"Reading from '{path}' as lines");

            string[] lines = File.ReadAllLines(path);
            Array.ForEach(lines, line => Console.WriteLine(line));

            Console.WriteLine($"Reading from '{path}' as text");

            string text = File.ReadAllText(path);
            Console.WriteLine(text);
            Console.WriteLine($"Text length: {text.Length}");

            byte[] bytes = File.ReadAllBytes(path);
            Array.ForEach(bytes, b => Console.WriteLine(b.ToString("X2")));

            AddTimestampToFile("times.log");
        }

        public static void AddTimestampToFile(string path)
        {
            DateTime now = DateTime.UtcNow;
            string timestamp = now.ToString("u");


            File.AppendAllLines(path, new[] { timestamp });
        }
    }
}
