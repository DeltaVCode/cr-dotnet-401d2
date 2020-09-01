using System;
using Xunit;

namespace Demo
{
    public class PoolParty : Party, IPoolParty
    {
        private int poolLength;

        public int PoolLength
        {
            get => poolLength;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), "Length must be positive!");

                poolLength = value;
            }
        }

        public int PoolWidth { get; set; }
        public decimal PoolDepth { get; set; }

        public decimal PoolVolume => PoolLength * PoolWidth * PoolDepth + 1;

        // Inherited from Party, and we *have to* implement it
        public override bool HasBooze
        {
            get { return false; }
        }

        public int EmptyThePool()
        {
            return 360;
        }

        public override void Setup()
        {
            Console.WriteLine("Clean the pool!");
            Console.WriteLine("Set out some towels");
        }
    }

    public class BoozyPoolParty : PoolParty
    {
        public override bool HasBooze => true;

        public override void Setup()
        {
            base.Setup();

            Console.WriteLine("Buy some booze");
        }

        public override void Teardown()
        {
            Console.WriteLine("Pick up some cans");
        }
    }

    public class PoolPartyFacts
    {
        [Fact]
        public void Parties_can_has_boozy()
        {
            PoolParty pp = new PoolParty
            {
                Budget = 12m
            };
            Assert.False(pp.HasBooze);
            pp.Setup();
            pp.Teardown();

            BoozyPoolParty bpp = new BoozyPoolParty
            {
                Budget = 1200m,
                PoolLength = 5,
                PoolWidth = 20,
                PoolDepth = 5,
            };
            Assert.True(bpp.HasBooze);
            Assert.Equal(500, bpp.PoolVolume);
            bpp.Setup();
            bpp.Teardown();
        }
    }
}