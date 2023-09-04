using System;

namespace Utilities
{
    public class Device
    {
        public Probe[] ProbeList { get; set; }

        public Device()
        {
            Config.Load();

            ProbeList = new Probe[Config.Instance.ProbeNumber];
            for (int i = 0; i < ProbeList.Length; i++) 
            { 
                ProbeList[i] = new Probe();
            }
        }

        public bool Print()
        {
            Console.WriteLine($"Tipologia dispositivo : {Config.Instance.DeviceName}\n");
            int i = 1;
            foreach (var sensore in ProbeList)
            {
                Console.WriteLine($"Il {i}° sensore ha rilevato :");
                sensore.PrintMeasures();
                Console.WriteLine("");
                i++;
            }
            return true;
        }

        public bool Send()
        {
            return Config.Send(ProbeList);
        }

    }    
}
