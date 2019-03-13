using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM
{
    public class AirTrafficOutputter : IOutputter
    {
        public void ConditionDetected(ITrack track1, ITrack track2, List<ITrack> trackables)
        {
            throw new NotImplementedException();
        }

        public void UpdateTrackDisplay(List<ITrack> trackables)
        {
            throw new NotImplementedException();
        }
    }
}