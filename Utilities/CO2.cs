using System;

namespace Utilities
{
    public class CO2 : IMeasure
    {
        public string Name { get { return "CO2"; } }

        public float Value
        {
            get
            {
                Random rng = new Random();
                return rng.Next(800, 1500);
            }
        }

        public float Print()
        {
            float res = Value;
            Console.WriteLine($"La C02 misurata equivale a: {res}ppm");
            return res;
        }
    }
}
