﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWT_Team22_ATM.Validation
{
    public interface IValidateEvent
    {
        event EventHandler<ValidateEventArgs> ValidationEvent;
    }
}