using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_Team22_ATM.Validation
{
    class ValidateTransponderData : IValidateEvent
    {
        public event EventHandler<ValidateEventArgs> ValidationEvent;

        protected virtual void OnNewValidation(ValidateEventArgs e)
        {
            ValidationEvent?.Invoke(this, e);
        }
    }
}
