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

        public ValidateEventArgs(List<ITrack> newInAirspaceTracks, List<ITrack> notInAirspaceButUsedToBeTracks, List<ITrack> stillInAirspaceTracks)
        {
            NewInAirspace = newInAirspaceTracks;
            NotInAirspaceButUsedToBe = notInAirspaceButUsedToBeTracks;
            StillInAirspace = stillInAirspaceTracks;
        }

        public List<ITrack> NewInAirspace { get; set; }
        public List<ITrack> NotInAirspaceButUsedToBe { get; set; }
        public List<ITrack> StillInAirspace { get; set; }

    }
}
