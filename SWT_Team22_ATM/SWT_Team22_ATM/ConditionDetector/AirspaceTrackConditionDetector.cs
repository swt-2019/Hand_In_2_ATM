using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM.ConditionDetector
{
    class AirspaceTrackConditionDetector : IConditionDetector
    {
        public EventHandler<ConditionEventArgs> Conditions { get; set; }
        List<IConditionStrategy<ITrack>> ConditionToCheckFor = new List<IConditionStrategy<ITrack>>()
        {
            new TrackHorizontalDistanceCondition(),
            new TrackAltitudeCondition()
        };

        public void DetectCondition(ITrackable trackable, ITrack toTrack)
        {
            trackable.Trackables.ForEach(track =>
            {
                ConditionToCheckFor.ForEach(c =>
                {
                    if(c.ConditionBetween(toTrack, track))
                        Conditions.Invoke(this,new ConditionEventArgs(toTrack,track));
                });
            });
        }
    }
}
