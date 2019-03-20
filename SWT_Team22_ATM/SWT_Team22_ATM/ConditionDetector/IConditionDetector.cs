using System;
using System.Collections.Generic;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM.ConditionDetector
{
    public interface IConditionDetector
    {
        event EventHandler<ConditionEventArgs> ConditionsHandler;
        void DetectCondition(ITrackable trackable);
    }
}