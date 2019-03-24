using System;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM.Updater.ICalculateTracks
{
    public class TrackHorizontalDistanceCalculator : ITrackCalculator<double>
    {
        public double Calculate(ITrack firstTrack, ITrack secondTrack)
        {
            var xDir = firstTrack.TrackPosition.XCoordinate - secondTrack.TrackPosition.XCoordinate;
            var yDir = firstTrack.TrackPosition.YCoordinate - secondTrack.TrackPosition.YCoordinate;
            return Hypotenuse(xDir,yDir);
        }

        public double Hypotenuse(int a, int b)
        {
            return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }
    }
}