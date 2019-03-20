﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM.Validation
{
    public class TrackAirspaceValidator : IValidator
    {

        public bool Validate(ITrack track, ITrackable airspace)//returns true if already Tracked
        {
            return airspace.Trackables.All(t => IsTrackAlreadyRegistered(t, track)) == false;
        }

        private bool IsTrackAlreadyRegistered(ITrack track, ITrack toCompareWithTag)//returns false if Tag is == Tag in the Trackable collection
        {
            return track.Tag != toCompareWithTag.Tag;
        }
    }
}
