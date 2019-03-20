using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SWT_Team22_ATM.Domains;
using SWT_Team22_ATM.Monitors;
using SWT_Team22_ATM.Validation;

namespace SWT_Team22_ATM.Validation
{
    public class ValidateTransponderData
    {


        PositionAirspaceValidator psAirspaceValidator = new PositionAirspaceValidator();


        private ITrafficMonitor _monitor;

        public ValidateTransponderData(ref IValidateEvent validateEvent, Monitors.ITrafficMonitor monitor)
        {
            validateEvent.ValidationEvent += OnNewValidation;
            _monitor = monitor;
        }

        private void OnNewValidation(object sender, ValidateEventArgs e)
        {
            psAirspaceValidator.Validate(e.Track, _monitor.Airspace);
        }
    }
}
