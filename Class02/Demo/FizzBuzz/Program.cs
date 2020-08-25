using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            ArgsDemo(args);
        }

        static void ArgsDemo(string[] args)
        {
            Console.WriteLine("Hello World!");

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("{0}: {1}", i, args[i]);
            }
        }
    }
}
