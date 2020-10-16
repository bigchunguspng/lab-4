using System.Collections.Generic;

namespace Task_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Star sun = new Star("Sun", 1392684, 1.41E18, 1.9881E27, 274.4, "Milky Way", 5772);
            Planet earth = new Planet("Earth", 12742, 1.08321E12, 5.972E21, 9.8, 101.325, true, sun);
            Moon moon = new Moon("Moon", 3475, 2.1958E10, 7.342E19, 1.62, earth);
            CelestialBody oumuamua = new CelestialBody("ʻOumuamua", 0.230, 0.0002, 0, 0);
            
            object[] bodies = {sun, earth, moon, oumuamua};
            foreach (CelestialBody body in bodies) body.Info();
        }
    }
}