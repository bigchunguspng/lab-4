using System.Diagnostics;

namespace Task_1
{
    public class Vehicle : Product
    {
        private readonly float _speed;
        private readonly int _passengers;

        public Vehicle(double price, string producer, string owner, float speed, int passengers) : base(price, producer,
            owner)
        {
            _speed = speed;
            _passengers = passengers;
        }
        
        public void Info()
        {
            base.Info(true);
            Debug.WriteLine($"{nameof(Vehicle)} characteristics");
            Debug.WriteLine($"Speed: {_speed}");
            Debug.WriteLine($"Max passengers: {_passengers}\n");
        }
    }
}