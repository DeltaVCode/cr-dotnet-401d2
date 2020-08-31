using System;
using Xunit;

namespace Demo
{
    abstract class Party
    {
        public decimal Budget { get; set; }

        public abstract bool HasBooze { get; }

        /// <summary>
        /// Stuff that needs to be done before the party can happen
        /// </summary>
        public abstract void Setup();

        public virtual void Teardown()
        {
            Console.WriteLine("No teardown required");
        }
    }

    public class PartyFacts
    {
        [Fact]
        public void Cannot_create_general_Party()
        {
            // abstract means you can't make one on its own
            // have to create a subclass
            // Party party = new Party();

            Party[] parties = new Party[]
            {
                new PoolParty(),
                new KidBirthdayParty(4, "Sue"),
                new BoozyPoolParty(),
            };

            Array.ForEach(parties, (Party p) =>
            {
                p.Setup();

                p.Teardown();
            });
        }
    }
}
