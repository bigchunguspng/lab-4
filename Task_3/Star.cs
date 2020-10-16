using System.Diagnostics;

namespace Task_3
{
    public class Star : CelestialBody
    {
        private readonly string _galaxy;
        private readonly double _photosphereTemperature;

        public Star(string name, double diameter, double volume, double mass, double gravity, string galaxy, double photosphereTemperature) : base(name, diameter, volume, mass, gravity)
        {
            _galaxy = galaxy;
            _photosphereTemperature = photosphereTemperature;
        }
        
        public override void Info()
        {
            base.Info();
            Debug.WriteLine($"It is located in {_galaxy} galaxy and has photosphere temperature of {_photosphereTemperature} K.");
        }
    }
}