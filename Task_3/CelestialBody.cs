using System.Diagnostics;

namespace Task_3
{
    public class CelestialBody
    {
        public readonly string Name;
        private readonly double _diameter;
        private readonly double _volume;
        private readonly double _mass;
        private readonly double _gravity;

        public CelestialBody(string name, double diameter, double volume, double mass, double gravity)
        {
            Name = name;
            _diameter = diameter;
            _volume = volume;
            _mass = mass;
            _gravity = gravity;
        }

        public virtual void Info() =>
            Debug.WriteLine(
                $"\n{Name} is {_diameter} kilometers in diameter" + (_mass == 0
                    ? ". "
                    : $", has volume of {_volume} cubic kilometers and mass of {_mass} tonnes. Surface gravity equals {_gravity} m/s^2. "
                ));
    }
}