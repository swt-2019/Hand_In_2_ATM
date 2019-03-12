using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM.ConditionDetector
{
    public class TrackHorizontalDistanceCondition : IConditionStrategy<ITrack>
    {
        public int HorizontalDistance { get; set; }

        public bool ConditionBetween(ITrack check, ITrack comparedTo)
        {
            var horizontalDistanceBetween = check.TrackPosition.XCoordinate - comparedTo.TrackPosition.XCoordinate;
            return horizontalDistanceBetween < HorizontalDistance;
        }
    }
}
