using System.Diagnostics;

namespace Task_3
{
    public class Moon : CelestialBody
    {
        private readonly Planet _planet;
        
        public Moon(string name, double diameter, double volume, double mass, double gravity, Planet planet) : base(name, diameter, volume, mass, gravity)
        {
            _planet = planet;
        }

        public override void Info()
        {
            base.Info();
            Debug.WriteLine($"It is natural satellite of {_planet.Name}.");
        }
    }
}