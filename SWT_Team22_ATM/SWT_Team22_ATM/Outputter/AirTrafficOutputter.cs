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

        public void ConditionDetected(ITrack track1, ITrack track2, List<ITrack> trackables)
        {
            Logger.LogCondition(track1, track2);
            TrafficController.DisplayConditions(track1, track2, trackables);
        }

        public void UpdateTrackDisplay(List<ITrack> trackables)
        {
            TrafficController.DisplayTracks(trackables);
        }
    }
}