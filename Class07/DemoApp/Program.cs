using System;
using Demo;

namespace DemoApp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Party[] parties = new Party[]
            {
                new PoolParty(),
                new KidBirthdayParty(4, "Sue"),
                new BoozyPoolParty(),
                new BouncyQuince(),
                new KidBirthdayPoolParty(12, "Ryan"),
            };

            foreach (Party party in parties)
            {
                Console.WriteLine(party.GetType().Name);
                Console.WriteLine($"Budget: {party.Budget}");
                Console.WriteLine($"Booze? {(party.HasBooze ? "Yes" : "No")}");

                Console.WriteLine("------------------");
                party.Setup();
                Console.WriteLine("------------------");

                if (party is IPoolParty poolParty)
                {
                    ShowPoolPartyInfo(poolParty);
                }

                if (party is IHasBounceHouse bounceHouse)
                {
                    ShowBounceHouseInfo(bounceHouse);
                }

                Console.WriteLine("------------------");
                party.Teardown();
                Console.WriteLine("------------------");

                Console.WriteLine();
            }
        }

        private static void ShowBounceHouseInfo(IHasBounceHouse bounceHouse)
        {
            Console.WriteLine($"Power Required: {bounceHouse.PowerRequirement} watts");
        }

        private static void ShowPoolPartyInfo(IPoolParty poolParty)
        {
            Console.WriteLine($"Pool Volume: {poolParty.PoolVolume}");
        }
    }
}