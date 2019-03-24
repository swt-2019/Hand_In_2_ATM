using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Team22_ATM.Domains;
using SWT_Team22_ATM.Validation;

namespace SWT_Team22_ATM.Monitors
{
    public interface ITrafficMonitor
    {
        ITrackable Airspace { get; }
        void Update(object sender, ValidateEventArgs e);
    }
}
