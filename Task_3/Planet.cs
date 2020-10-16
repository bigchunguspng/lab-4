using System.Diagnostics;

namespace Task_3
{
    public class Planet : CelestialBody
    {
        private readonly double _surfacePressure;
        private readonly bool _habitable;
        private readonly Star _star;

        public Planet(string name, double diameter, double volume, double mass, double gravity, double surfacePressure, bool habitable, Star star) : base(name, diameter, volume, mass, gravity)
        {
            _surfacePressure = surfacePressure;
            _habitable = habitable;
            _star = star;
        }

        public override void Info()
        {
            base.Info();
            Debug.WriteLine($"It's rotating around {_star.Name},{(_habitable ? " is habitable and" : "")} has surface pressure of {_surfacePressure} kPa.");
        }
    }
}