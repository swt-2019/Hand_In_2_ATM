using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM.Validation
{
    public class ValidateEventArgs : EventArgs
    {
        public List<ITrack> NewInAirspace { get; set; }
        public List<ITrack> NotInAirspaceButUsedToBe { get; set; }
        public List<ITrack> StillInAirspace { get; set; }

    }
}
