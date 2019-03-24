using System.Collections.Generic;
using SWT_Team22_ATM.ConditionDetector;
using SWT_Team22_ATM.Domains;
using SWT_Team22_ATM.Validation;

namespace SWT_Team22_ATM.Monitors
{
    public class AirTrafficMonitor : ITrafficMonitor
    {
        private readonly IValidateEvent _validator;
        private readonly IConditionDetector _conditionDetector;
        private IOutputter _outputter;
        public AirTrafficMonitor(IValidateEvent validator, IConditionDetector conditionDetector, IOutputter outputter)
        {
            _validator = validator;
            _validator.ValidationCompleteEventHandler += Update;
            _conditionDetector = conditionDetector;
            _conditionDetector.ConditionsHandler += ConditionDetector_ConditionsHandler;
            _outputter = outputter;
        }
        
        public ITrackable Airspace { get; set; }
        public List<ConditionEventArgs> Conditions { get; set; }
        public void Update(object sender, ValidateEventArgs e)
        {
            
        }

        private void ConditionDetector_ConditionsHandler(object sender, ConditionEventArgs e)
        {
            Conditions.Add(e);
            //Outputter.Logger.LogCondition(e.FirstConditionHolder,e.SecondConditionHolder);
            //Outputter.(Airspace);
        }
    }
}