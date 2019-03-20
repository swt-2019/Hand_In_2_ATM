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

        public void DetectCondition(ITrackable trackable)
        {
            var tracksToCheck = trackable.Trackables;
            for (int i = 0; i < tracksToCheck.Count; i++)
            {
                for (int j = i + 1; j < tracksToCheck.Count; j++)
                {
                    DetectTrackOnTrackCondition(tracksToCheck[i],tracksToCheck[j]);
                }
            }
        }

        public void DetectTrackOnTrackCondition(ITrack firstTrack, ITrack secondTrack)
        {

            ConditionToCheckFor.ForEach(c =>
            {
                if (c.ConditionBetween(firstTrack, secondTrack))
                    OnCondition(new ConditionEventArgs(firstTrack, secondTrack));

            });
        }

        private void OnCondition(ConditionEventArgs e)
        {
            ConditionsHandler?.Invoke(this, e);
        }
    }
}
