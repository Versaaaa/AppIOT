using System;
using System.Diagnostics.SymbolStore;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Utilities;


namespace Exercise0004
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Device device = new Device();
            Console.WriteLine("Digita \"x\" se si vuole specificare un file Configuration diverso da quello default.");

            if (Console.ReadLine().ToLower().Equals("x"))
            {
                Console.WriteLine("Specificare il percorso del file Configuration");
                if (!Config.Load(Console.ReadLine()))
                {
                    Console.WriteLine("\nPercorso File inacessibile, il programma utilizzerà il file Configuration default");
                }
                else
                {
                    Console.WriteLine("Proseguimento del programma con file Configuration personalizzato");
                }
            }
            else 
            {
                Console.WriteLine("Proseguimento del programma con il percorso default");
            }
            device.Print();
            device.Send();
        }
    }    
    //public class DevicePro : IDevice
    //{
    //    public const string CONFIG_FILE = @"C:\Users\francesco.chen\source\repos\Net_Training\Utilities\config.txt.txt";
    //    public const int probeNumber = 4;
            
    //    public Probe[] ProbeList { get; set; }

    //    public DevicePro1()
    //    {
    //        ProbeList = new Probe[probeNumber];
    //        for (int i = 0; i < probeNumber; i++) 
    //        { 
    //            ProbeList[i] = new Probe();
    //        }

    //        Config.Load(CONFIG_FILE);
    //    }

    //    public bool Print()
    //    {
    //        Console.WriteLine("Device di tipo [Pro 1]");
    //        foreach (var sensore in ProbeList)
    //        {
    //            var i = sensore.GetMeasures();
    //            Console.WriteLine($"La temperatura misurata equivale a: {i["Temperatura"]}°C");
    //            Console.WriteLine($"La umidità misurata equivale a: {i["Umidita"]}%");

    //        }
    //        return true;
    //    }
    //}
    //public class DeviceSuper : IDevice
    //{
    //    public const string CONFIG_FILE = @"C:\Users\francesco.chen\source\repos\Net_Training\Utilities\config.txt.txt";
    //    public const int probeNumber = 4;
            
    //    public Probe[] ProbeList { get; set; }

    //    public DeviceSuper()
    //    {
    //        ProbeList = new Probe[probeNumber];
    //        for (int i = 0; i < probeNumber; i++) 
    //        { 
    //            ProbeList[i] = new Probe();
    //        }

    //        Config.Load(CONFIG_FILE);
    //    }

    //    public bool Print()
    //    {
    //        Console.WriteLine("Device di tipo [Super]");
    //        foreach (var sensore in ProbeList)
    //        {
    //            var i = sensore.PrintMeasures();
    //        }
    //        return true;
    //    }
    //}
}
