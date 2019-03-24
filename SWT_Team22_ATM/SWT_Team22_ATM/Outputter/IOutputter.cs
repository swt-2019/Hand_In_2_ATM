using System;
using System.Collections.Generic;
using SWT_Team22_ATM.ConditionDetector;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM
{
    public interface IOutputter
    {
        ILogger Logger { get; set; }
        ITrafficController TrafficController { get; set; }
        
        void ConditionDetected(List<ConditionEventArgs> conditions);
        // eventuelt ændre til ITrackAble airspace
        void UpdateTrackDisplay(Airspace airspace);
    }
}