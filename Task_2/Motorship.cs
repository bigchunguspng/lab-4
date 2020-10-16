using System.Diagnostics;

namespace Task_2
{
    public class Motorship : B
    {
        private int _fuelTankCapacity;
        private int _fuel;
        
        public Motorship(int capacity, float speed, int maxSailors, int durability, int cost, int fuelTankCapacity) : base(capacity, speed, maxSailors, durability, cost)
        {
            _fuelTankCapacity = fuelTankCapacity;
            _fuel = fuelTankCapacity;
        }
        
        public override void Sail()
        {
            base.Sail();
            _fuel -= 30;
        }

        public override void Info()
        {
            base.Info();
            Debug.WriteLine($"Fuel: {_fuel} gal");
        }
    }
}