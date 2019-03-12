using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM.ConditionDetector
{
    public class TrackAltitudeCondition : IConditionStrategy<ITrack>
    {
        public int AltitudeCondition { get; set; }
        public bool ConditionBetween(ITrack check, ITrack comparedTo)
        {
            var altitudeDiff = check.TrackPosition.ZCoordinate - comparedTo.TrackPosition.ZCoordinate;
            return altitudeDiff < AltitudeCondition;
        }
    }
}
