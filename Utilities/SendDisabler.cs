using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class SendDisabler : IServerTunnel
    {
        public bool CanConnect { get { return false; } }

        public bool Send(ICollection<Probe> probeList)
        {
            Console.WriteLine("La funzione è disabilitata.");
            return false;
        }
    }
}
