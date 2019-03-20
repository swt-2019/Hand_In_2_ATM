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
    public class ValidateTransponderData : IValidateEvent
    {
        public event EventHandler<ValidateEventArgs> ValidationEvent;

        private readonly PositionAirspaceValidator _positionAirspaceValidator = new PositionAirspaceValidator();

        public ValidateTransponderData(IValidateEvent validateEvent)
        {
            validateEvent.ValidationEvent += OnNewValidation;
        }


        private ITrafficMonitor monitor;


        private void OnNewValidation(object sender, ValidateEventArgs e)
        {
            e.TrackList.ForEach(track => _positionAirspaceValidator?.Validate(track, monitor.Airspace));
        }
    }
}
