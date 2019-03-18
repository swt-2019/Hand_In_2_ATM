using System;
using System.Collections.Generic;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM.ConditionDetector
{
    public class ConditionEventArgs : EventArgs
    {
        public ConditionEventArgs(ITrack first, ITrack second)
        {
            FirstConditionHolder = first;
            SecondConditionHolder = second;
        }
        public ITrack FirstConditionHolder { get; set; }
        public ITrack SecondConditionHolder { get; set; }
    }
}