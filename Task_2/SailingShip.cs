using System.Diagnostics;

namespace Task_2
{
    public class SailingShip : B
    {
        private readonly int _cannons;


        public SailingShip(int capacity, float speed, int maxSailors, int durability, int cost, int cannons) : base(capacity, speed, maxSailors, durability, cost) => _cannons = cannons;

        public override void Info()
        {
            base.Info();
            Debug.WriteLine($"Cannons: {_cannons}");
        }
    }
}