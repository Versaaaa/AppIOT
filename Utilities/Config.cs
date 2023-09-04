using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Utilities
{
    public class Config
    {
        private static Config instance;
        
        public string ConfigFile { get; set; } = Directory.GetCurrentDirectory() + @"\..\..\..\..\config.txt";

        /* Formattazione file config :

        1   NomeDispositivo
        2   NumeroSensori
        3   ServerTunnel
                    0 = SendDisabler
                    1 = SendEnabler
        4   CampoDaMisurare1
        5   CampoDaMisurare2
        6   CampoDaMisurare3
        ... ...

        */

        public List<string> Measures { get; set; }

        public IServerTunnel ServerTunnel { get; set; }

        public int ProbeNumber { get; set; }

        public string DeviceName { get; set; }

        public static Config Instance 
        {
            get 
            { 
                if (instance == null)
                {
                    instance = new Config();
                }
                return instance;
            } 
        }
        public static bool Load()
        {
            return PrivateLoad(Instance.ConfigFile);
        }
        public static bool Load(string path)
        {
            return PrivateLoad(path);
        }
        private static bool PrivateLoad(string path)
        {
            try
            {
                int probeNumber;
                string deviceName;
                IServerTunnel serverTunnel;
                List<string> measures;

                using (StreamReader sr = new StreamReader(path))
                {
                    probeNumber = int.Parse(sr.ReadLine());
                    deviceName = sr.ReadLine();

                    switch (sr.ReadLine())
                    {
                        case "0":
                            serverTunnel = new SendDisabler();
                            break;
                        case "1":
                            serverTunnel = new SendEnabler();
                            break;
                        default: throw new Exception(" Cannot Inizialize ServerTunnel ");
                    }

                    measures = sr.ReadToEnd().Split(Environment.NewLine).ToList();
                }

                Instance.Measures = measures;
                Instance.ServerTunnel = serverTunnel;
                Instance.ProbeNumber = probeNumber;
                Instance.DeviceName = deviceName;
                Instance.ConfigFile = path;
                
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
                return false;
            }
        }

        public static bool Send(ICollection<Probe> probes)
        {
            return Instance.ServerTunnel.Send(probes);
        }

        public static bool RemoveFields(int i)
        {
            try
            {
                Instance.Measures.RemoveAt(i);
                return true;
            }
            catch (Exception ex)
            { 
                Console.Write(ex.ToString());
                return false;
            }
        }

        private Config()
        {
                
        }
    }  
}
