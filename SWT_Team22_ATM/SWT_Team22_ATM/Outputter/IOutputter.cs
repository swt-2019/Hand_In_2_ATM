using System;
using System.Collections.Generic;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM
{
    public interface IOutputter
    {
        ILogger Logger { get; set; }
        ITrafficController TrafficController { get; set; }

        string PathToFile { get; set; }
        
        void ConditionDetected(List<Condtion> condtions, Airspace airspace);
        void UpdateTrackDisplay(Airspace airspace);
    }
}