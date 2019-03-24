using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM.Validation
{
    public class TrackAirspaceValidator : IValidator
    {
        public ITrack Track { get; set; }
        public ITrackable Trackable { get; set; }
        public bool Validate(ITrack track, ITrackable airspace)//returns true if already Tracked
        {
            Track = track;
            Trackable = airspace;
            return Trackable.Trackables.Exists(t=>IsTrackAlreadyRegistered(Track, t));
        }

        public bool IsTrackAlreadyRegistered(ITrack track, ITrack toCompareWithTag)//returns false if Tag is == Tag in the Trackable collection
        {
            return track.Tag == toCompareWithTag.Tag;
        }
    }
}
