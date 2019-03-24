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

        /// <summary>
        /// https://en.wikipedia.org/wiki/List_of_common_coordinate_transformations#From_Cartesian_coordinates
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public double TransformCartesianToPolarAngle(double angle)
        {
            if (angle >= 0 && angle < Math.PI / 2)
            {
                return angle;
            }
            else if (angle >= Math.PI/2 && angle < Math.PI )
            {
                return Math.PI - angle;
            }
            else if(angle >= Math.PI && angle < (3*Math.PI)/2)
            {
                return Math.PI + angle;
            }
            else
            {
                return 2 * Math.PI - angle;
            }
        }
    }
}