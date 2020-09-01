using Xunit;

namespace Demo
{
    public interface IPoolParty
    {
        decimal PoolDepth { get; set; }
        int PoolLength { get; set; }
        int PoolWidth { get; set; }

        // This does not work before C# 8
        decimal PoolVolume => PoolDepth * PoolLength * PoolWidth;

        /// <returns>Estimated number of minutes to drain</returns>
        int EmptyThePool();
    }

    public class IPoolPartyFacts
    {
        [Fact]
        public void CanMakeSomePoolParties()
        {
            IPoolParty p1 = new KidBirthdayPoolParty(12, "Ryan")
            {
                PoolLength = 5,
                PoolDepth = 5,
                PoolWidth = 5,
            };
            IPoolParty p2 = new BoozyPoolParty()
            {
                PoolWidth = 2,
                PoolLength = 2,
                PoolDepth = 31m,
            };

            IPoolParty[] parties = new[] { p1, p2 };

            foreach (var pp in parties)
            {
                Assert.Equal(125, pp.PoolVolume);
                Assert.True(pp.EmptyThePool() > 0);
            }
        }
    }
}