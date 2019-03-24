using System;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM.Updater.ICalculateTracks
{
    public class TrackCourseCalculator : ITrackCalculator<double>
    {
        public double Calculate(ITrack firstTrack, ITrack secondTrack)
        {
            var cartAngle = CalculateAngle(firstTrack, secondTrack);
            return (450 - cartAngle)%360;
        }

        public double CalculateAngle(ITrack firstTrack, ITrack secondTrack)
        {
            var xDiff = secondTrack.TrackPosition.XCoordinate - firstTrack.TrackPosition.XCoordinate;
            var yDiff = secondTrack.TrackPosition.YCoordinate - firstTrack.TrackPosition.YCoordinate;
            var angle = Math.Atan2(yDiff, xDiff);
            if (angle < 0.0)
                angle += Math.PI * 2;

            return angle * (180 / Math.PI);
        }
    }
}