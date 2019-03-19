using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SWT_Team22_ATM.interpreter;
using SWT_Team22_ATM.Monitors;
using SWT_Team22_ATM.Domains;
using SWT_Team22_ATM.Validation;
using SWT_TEAM22_ATM.Test.Unit.TestMonitors;


namespace SWT_TEAM22_ATM.Test.Unit
{
    
    public class ValidateTransponderTest
    {
        private Iinterpret _interpret;
        private IValidator _validator;
        private TraffikMonitorFake _fakeTrafficMonitor;
        private IValidateEvent _event_uut;

        [SetUp]
        public void Setup()
        {
            _fakeTrafficMonitor = new TraffikMonitorFake();
            Airspace airspace = new Airspace();
            airspace.AirspacePosition.XCoordinate = 20;
            airspace.AirspacePosition.YCoordinate = 40;
            airspace.AirspacePosition.ZCoordinate = 100;
            airspace.VerticalStart = 2000;
            airspace.VerticalEnd = 4000;

            _fakeTrafficMonitor.Airspace = airspace;


        }



    }
}
