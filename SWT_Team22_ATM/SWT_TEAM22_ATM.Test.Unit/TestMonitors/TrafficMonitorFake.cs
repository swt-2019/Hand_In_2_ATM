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
    public class TrafficMonitorFake : ITrafficMonitor
    {
        public TrafficMonitorFake(ref IValidateEvent validateEvent)
        {
            validateEvent.ValidationCompleteEventHandler += Update;
        }

        public List<ITrack> StillInAirspace = new List<ITrack>();
        public List<ITrack> UsedToBeInAirspace = new List<ITrack>();
        public List<ITrack> NewInAirspace = new List<ITrack>();

        public ITrackable Airspace { get; set; }

        public void Update(object sender, ValidateEventArgs e)
        {
            NewInAirspace = e.NewInAirspace;
            StillInAirspace = e.StillInAirspace;
            UsedToBeInAirspace = e.NotInAirspaceButUsedToBe;
        }
    }
}
