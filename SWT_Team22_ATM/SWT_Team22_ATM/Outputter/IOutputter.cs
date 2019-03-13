using System;
using System.Collections.Generic;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM
{
    public interface IOutputter
    {
        ILogger Logger { get; set; }
        ITrafficController TrafficController { get; set; }
        void ConditionDetected(ITrack track1, ITrack track2, List<ITrack> trackables);
        void UpdateTrackDisplay(List<ITrack> trackables);
    }
}