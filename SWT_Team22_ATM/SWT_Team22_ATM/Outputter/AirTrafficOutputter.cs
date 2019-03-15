using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM
{
    public class AirTrafficOutputter : IOutputter
    {
        public ILogger Logger { get; set; }
        public ITrafficController TrafficController { get; set; }

        public string PathToFile { get; set; }
        public void ConditionDetected(List<Condtion> condtions, Airspace airspace)
        {
            foreach (var condtion in condtions)
            {
                Logger.LogCondition(condtion.Track1, condtion.Track2, PathToFile);
            }
            TrafficController.DisplayConditions(condtions, airspace.Trackables);
        }

        public void UpdateTrackDisplay(Airspace airspace)
        {
            TrafficController.DisplayTracks(airspace.Trackables);
        }
    }
}