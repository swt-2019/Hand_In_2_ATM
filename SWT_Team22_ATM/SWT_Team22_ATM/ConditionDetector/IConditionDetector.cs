using System;
using System.Collections.Generic;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM.ConditionDetector
{
    public interface IConditionDetector
    {
        EventHandler<ConditionEventArgs> Conditions { get; set; }
        void DetectCondition(ITrackable trackable, ITrack tracker);
    }
}