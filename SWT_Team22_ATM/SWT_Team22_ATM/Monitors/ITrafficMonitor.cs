using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM.Monitors
{
    public interface ITrafficMonitor
    {
        Airspace Airspace { get; set; }
    }
}
