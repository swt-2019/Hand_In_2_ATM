using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM.ConditionDetector
{
    public class AirspaceTrackConditionDetector : IConditionDetector
    {
        public event EventHandler<ConditionEventArgs> ConditionsHandler;
        public List<IConditionStrategy<ITrack>> ConditionToCheckFor { get; set; }

        public AirspaceTrackConditionDetector(List<IConditionStrategy<ITrack>> conditionsToCheckFor)
        {
            ConditionToCheckFor = conditionsToCheckFor;
        }

        public void DetectCondition(ITrackable trackable, ITrack toTrack)
        {
            trackable.Trackables.ForEach(track =>
            {
                ConditionToCheckFor.ForEach(c =>
                {
                    if(c.ConditionBetween(toTrack, track))
                        OnCondition(new ConditionEventArgs(toTrack,track));

                });
            });
        }

        private void OnCondition(ConditionEventArgs e)
        {
            ConditionsHandler?.Invoke(this, e);
        }
    }
}
