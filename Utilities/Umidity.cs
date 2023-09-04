using System;

namespace Utilities
{
    public class Umidity : IMeasure
    {
        public string Name { get { return "Umidita"; } }

        public float Value
        {
            get
            {
                Random rng = new Random();
                return rng.Next(101) + (float)rng.NextDouble();
            }
        }

        public float Print()
        {
            float res = Value;
            Console.WriteLine($"La umidità misurata equivale a: {res}%");
            return res;
        }
    }
}
