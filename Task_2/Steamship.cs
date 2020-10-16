using System.Diagnostics;

namespace Task_2
{
    public class Steamship : B
    {
        private readonly int _pipes;
        private int _fuelTankCapacity;
        private int _fuel;
        
        public Steamship(int capacity, float speed, int maxSailors, int durability, int cost, int pipes, int fuelTankCapacity) : base(capacity, speed, maxSailors, durability, cost)
        {
            _pipes = pipes;
            _fuelTankCapacity = fuelTankCapacity;
            _fuel = fuelTankCapacity;
        }
        
        public override void Sail()
        {
            base.Sail();
            _fuel -= 50;
        }

        public override void Info()
        {
            base.Info();
            Debug.WriteLine($"Pipes: {_pipes}");
            Debug.WriteLine($"Fuel: {_fuel} t");
        }
    }
}