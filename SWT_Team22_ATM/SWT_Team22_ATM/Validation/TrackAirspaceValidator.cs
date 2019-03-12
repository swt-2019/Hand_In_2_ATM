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
        public Airspace Airspace { get; private set; }
        /*public Track Track { get; private set; }
*/
        public TrackAirspaceValidator(Airspace airspace)
        {
            Airspace = airspace;
        }

        public bool Validate(ITrack track)//returns true if already Tracked
        {
            return Airspace.Trackables.All(t => IsTrackAlreadyRegistered(t, track)) == false;
        }

        private bool IsTrackAlreadyRegistered(ITrack track, ITrack toCompareWith)//returns false if Tag is == to a Tag in the Trackable collection
        {
            return track.Tag != toCompareWith.Tag;
        }
    }
}
