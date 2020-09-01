using System;
using Xunit;

namespace Demo
{
    public abstract class BirthdayParty : Party
    {
        public BirthdayParty(int age)
        {
            Age = age;
        }

        public int Age { get; }

        public virtual string SingHappyBirthday()
        {
            return "Happy birthday to you...";
        }
    }

    public class KidBirthdayParty : BirthdayParty
    {
        public KidBirthdayParty(int age, string name) : base(age)
        {
            Name = name;
        }

        public string Activities { get; set; }

        public override bool HasBooze => false;

        public string Name { get; }

        public override void Setup()
        {
            Console.WriteLine("Buy some gifts");
        }
    }

    public class KidBirthdayPoolParty : KidBirthdayParty, IPoolParty
    {
        public KidBirthdayPoolParty(int age, string name)
            : base(age, name)
        {
        }

        public decimal PoolDepth { get; set; }
        public int PoolLength { get; set; }
        public int PoolWidth { get; set; }

        public int EmptyThePool()
        {
            return 90;
        }
    }

    public class QuinceaneraParty : BirthdayParty
    {
        public QuinceaneraParty() : base(15)
        {
        }

        public override bool HasBooze => true;

        public override void Setup()
        {
            Console.WriteLine("Big fancy dress!");
        }

        public override string SingHappyBirthday()
        {
            return "Feliz cumpleanos";
        }
    }

    public class BouncyQuince : QuinceaneraParty, IHasBounceHouse
    {
        public int BounceHouseCapacity => 5;
        public double PowerRequirement => 200;

        public void ChangeBouncers()
        {
            Console.WriteLine("GTFO");
        }
    }

    public class BirthdayPartyFacts
    {
        [Fact]
        public void Age_is_required()
        {
            BirthdayParty kid = new KidBirthdayParty(7, "Jon");
            Assert.Equal(7, kid.Age);

            BirthdayParty quince = new QuinceaneraParty();
            quince.Budget = 1000000;
            Assert.Equal(1000000.00m, quince.Budget);
            Assert.Equal(15, quince.Age);
            Assert.Equal("Feliz cumpleanos", quince.SingHappyBirthday());

            BirthdayParty[] parties = new[]
            {
                kid, quince,

                new KidBirthdayParty(3, "Juan"),
            };

            Array.ForEach(parties, (BirthdayParty bp) =>
            {
                bp.Setup();
                Console.WriteLine(bp.SingHappyBirthday());
                bp.Teardown();
            });
        }
    }
}