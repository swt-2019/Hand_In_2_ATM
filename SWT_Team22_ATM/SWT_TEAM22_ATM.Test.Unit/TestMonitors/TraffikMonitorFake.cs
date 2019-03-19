using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Team22_ATM.Domains;
using SWT_Team22_ATM.Monitors;
using SWT_Team22_ATM.Validation;

namespace SWT_TEAM22_ATM.Test.Unit.TestMonitors
{
    public class TraffikMonitorFake : ITrafficMonitor
    {
        public Airspace Airspace { get; set; }

    }
}
