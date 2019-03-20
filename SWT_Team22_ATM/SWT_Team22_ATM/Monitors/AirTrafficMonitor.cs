using System.Collections.Generic;
using SWT_Team22_ATM.ConditionDetector;
using SWT_Team22_ATM.Domains;

namespace SWT_Team22_ATM.Monitors
{
    public class AirTrafficMonitor : ITrafficMonitor
    {
        public AirTrafficMonitor()
        {
            ConditionDetector.ConditionsHandler += ConditionDetector_ConditionsHandler;
        }

        public List<ConditionEventArgs> ConditionsList { get; set; }
        public ITrackable Airspace { get; set; }
        public IConditionDetector ConditionDetector { get; set; }
        public IOutputter Outputter { get; set; }
        public void Update(ITrack track)
        {
            throw new System.NotImplementedException();
        }

        private void ConditionDetector_ConditionsHandler(object sender, ConditionEventArgs e)
        {
            if (ConditionsList.Exists(c => c == e) == true)
                return;

        }
    }
}