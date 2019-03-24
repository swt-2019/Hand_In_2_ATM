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
        public void Update(List<ITrack> needsUpdate, List<ITrack> theUpdate)
        {
            foreach (var track in theUpdate)
            {
                var secondTrack = theUpdate.Find(t => t.Tag == track.Tag);
                if (secondTrack == null)
                    continue;
                track.Speed = _speedCalculator.Calculate(track, secondTrack);
                track.Course = _trajectoryCalculator.Calculate(track, secondTrack);
            }
        }
    }
}