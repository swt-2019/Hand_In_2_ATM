using System;
using System.Collections.Generic;
using System.Linq;
using SWT_Team22_ATM.Domains;
using SWT_Team22_ATM.Updater.ICalculateTracks;

namespace SWT_Team22_ATM.Updater
{
    public class AirspaceUpdater : IUpdater<List<ITrack>>
    {
        private readonly ITrackCalculator<double> _speedCalculator;
        private readonly ITrackCalculator<double> _trajectoryCalculator;

        public AirspaceUpdater(ITrackCalculator<double> speedCalculator, ITrackCalculator<double> courseCalculator)
        {
            _speedCalculator = speedCalculator;
            _trajectoryCalculator = courseCalculator;
        }
        public void Update(ref List<ITrack> needsUpdate, List<ITrack> theUpdate)
        {
            foreach (var track in theUpdate)
            {
                var trackHistory = needsUpdate.Find(t => t.Tag == track.Tag);
                if (trackHistory == null)
                    continue;
                track.Speed = _speedCalculator.Calculate(trackHistory, track);
                track.Course = _trajectoryCalculator.Calculate(trackHistory, track);
            }

            needsUpdate = theUpdate;
        }
    }
}