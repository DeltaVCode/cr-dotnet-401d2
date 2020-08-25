using System;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            FizzBuzzDemo();
            //ArgsDemo(args);
            //StringToWhateverDemo();
        }

        static void FizzBuzzDemo()
        {
            // Print numbers 1 through 100
            // but print Fizz if a multiple of 3
            //     print Buzz if a multiple of 5
            //     print FizzBuzz if a multiple of both
            for (int n = 1; n < 100; n++)
            {
                var fizzBuzzed = FizzBuzzer.Convert(n);
                Console.WriteLine($"{n}: {fizzBuzzed}");
            }
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
