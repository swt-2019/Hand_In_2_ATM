using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SWT_Team22_ATM.ConditionDetector;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM
{
    public class AirTrafficOutputter : IOutputter
    {
        public ILogger Logger { get; set; }
        public ITrafficController TrafficController { get; set; }

        public void ConditionDetected(List<ConditionEventArgs> conditions)
        {   
            foreach (var condtion in conditions)
            {
                Logger.LogCondition(condtion.FirstConditionHolder, condtion.SecondConditionHolder);
            }
            TrafficController.DisplayConditions(conditions);
        }

        public void UpdateTrackDisplay(Airspace airspace)
        {
            TrafficController.DisplayTracks(airspace.Trackables);
        }
    }
}