namespace Demo
{
    public interface IHasBounceHouse
    {
        int BounceHouseCapacity { get; }
        double PowerRequirement { get; }

        void ChangeBouncers();
    }
}