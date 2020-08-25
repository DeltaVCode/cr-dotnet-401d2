using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            ArgsDemo(args);
            StringToWhateverDemo();
        }

        static void ArgsDemo(string[] args)
        {
            Console.WriteLine("Hello World!");

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("{0}: {1}", i, args[i]);
            }
        }

        static void StringToWhateverDemo()
        {
            Console.Write("What is your name? ");
            string name = Console.ReadLine();

            Console.Write("What is your age?");
            int age = int.Parse(Console.ReadLine());

            if (age < 13)
            {
                Console.WriteLine("Minors not allowed");
            }

            // To make an array that contains mixed types:
            object[] stuff = new object[] { name, age };
            Array.ForEach(stuff, o => Console.WriteLine(o));
        }
    }
}
