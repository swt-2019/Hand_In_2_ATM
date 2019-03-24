using System;
using System.Globalization;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM.Updater.ICalculateTracks
{
    public class TrackSpeedCalculator : ITrackCalculator<double>
    {
        private ITrackCalculator<double> _trackHorizontalDistanceCalculator;

        public TrackSpeedCalculator(ITrackCalculator<double> trackHorizontalDistanceCalculator)
        {
            _trackHorizontalDistanceCalculator = trackHorizontalDistanceCalculator;
        }

        public double Calculate(ITrack firstTrack, ITrack secondTrack)
        {
            var dist = _trackHorizontalDistanceCalculator.Calculate(firstTrack, secondTrack);
            var timeFirstTrack = ConvertTimeStringToDateTime(firstTrack.TimeStamp);
            var timeSecondTrack = ConvertTimeStringToDateTime(secondTrack.TimeStamp);
            var timeDiff = Math.Abs(timeFirstTrack.Subtract(timeSecondTrack).TotalSeconds);

            return dist / timeDiff;
        }

        public DateTime ConvertTimeStringToDateTime(string time)
        {
            try
            {
                string format = "yyyyMMddHHmmssFFF";
                DateTime result = new DateTime();
                if (DateTime.TryParseExact(time, format, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal, out result) == false)
                {

                    throw new ArgumentException("Input was not a valid DateTime");
                }
                return result;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}