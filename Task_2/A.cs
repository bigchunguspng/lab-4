using System.Collections.Generic;

namespace Task_2
{
    /// <summary>
    /// Marine convoy's escort
    /// </summary>
    public class A
    {
        private readonly List<B> _ships;

        public A(B a, B b, B c = null)
        {
            _ships = new List<B> {a, b};
            if (c != null) _ships.Add(c);
        }

        public void SailTheRoute(int days)
        {
            foreach (var ship in _ships)
                for (int i = 0; i < days; i++)
                    ship.Sail();
        }
        public void Info()
        {
            foreach (var ship in _ships) ship.Info();
        }
    }
}