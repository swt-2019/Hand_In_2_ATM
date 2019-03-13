﻿using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM.ConditionDetector
{
    public class TrackHorizontalDistanceCondition : IConditionStrategy<ITrack>
    {
        public int HorizontalDistance { get; set; }

        public bool ConditionBetween(ITrack check, ITrack comparedTo)
        {
            var xDistanceBetween = check.TrackPosition.XCoordinate - comparedTo.TrackPosition.XCoordinate;
            var yDistanceBetween = check.TrackPosition.YCoordinate - comparedTo.TrackPosition.YCoordinate;
            return xDistanceBetween < HorizontalDistance || yDistanceBetween < HorizontalDistance;
        }
    }
}
