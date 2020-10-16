using System.Diagnostics;

namespace Task_2
{
    /// <summary>
    /// Ship (any era)
    /// </summary>
    public class B
    {
        private readonly int _maxSailors;
        private readonly int _cost;
        private readonly int _capacity;
        private readonly float _speed;
        private int _sailors;
        private int _durability;

        public B(int capacity, float speed, int maxSailors, int durability, int cost)
        {
            _capacity = capacity;
            _speed = speed;
            _maxSailors = maxSailors;
            HireSailors(maxSailors);
            _durability = durability;
            _cost = cost;
        }

        public virtual void Sail() //call once per day
        {
            _durability--;
            Program.Account -= _cost;
        }

        private void HireSailors(int sailors) => _sailors = sailors < _maxSailors ? _sailors + sailors : _maxSailors;
        public void FireSailors(int people) => _sailors = people > _sailors ? 0 : _sailors - people;

        public virtual void Info()
        {
            Debug.WriteLine($"\nCapacity: {_capacity} bbl");
            Debug.WriteLine($"Speed: {_speed} kt");
            Debug.WriteLine($"Sailors: {_sailors}");
            Debug.WriteLine($"Durability: {_durability}");
        }
    }
}