using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class SendEnabler : IServerTunnel
    {
        public bool CanConnect { get { return true; } }
        public string serverPath 
        { 
            get 
            { 
                return 
                    Directory.GetCurrentDirectory() + @"\..\..\..\..\Record" + 
                    DateTime.Now.Date.ToString("d").Replace("/", "_") + 
                    DateTime.Now.TimeOfDay.ToString("g").Replace(":", "_") + 
                    ".txt"; 
            }
        } 
        public bool Send(ICollection<Probe> probeList)
        {
            bool res = true;
            try
            {
                using (StreamWriter sw = new StreamWriter(serverPath))
                {
                    foreach (var probe in probeList)
                    {
                        string text = "";
                        foreach (var measure in probe.LastRecord.Keys)
                        {
                            text += $"{measure} = {probe.LastRecord[measure]}\n";
                        }
                        sw.WriteLine(text);
                    }
                }
                Console.WriteLine($"File Record inviato a : \n{Directory.GetParent(serverPath)}");
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.ToString());
                res = false;
            }

            return res;
        }
    }
}
