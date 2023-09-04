using System;

namespace Utilities
{
    public class Temperature : IMeasure
    {
        public string Name { get { return "Temperatura"; } }

        public float Value
        {
            get
            {
                Random rng = new Random();
                return rng.Next(41) + (float)rng.NextDouble();
            }
        }

        public float Print()
        {
            float res = Value;
            Console.WriteLine($"La temperatura misurata equivale a: {res}°C");
            return res;
        }
    }
}
